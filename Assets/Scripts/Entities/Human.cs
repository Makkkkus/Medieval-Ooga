using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Human : Entity
{
    private Dictionary<ushort, Work> workQueue = new Dictionary<ushort, Work>();
    private Work currentWork;

    public Item currentItem;

    private NavMeshAgent nav;
    private Animator anim;

    private float velocity;

    private void Start()
    {
        maxAge = 100;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // This is used for animations.
        velocity = Mathf.Sqrt(Mathf.Pow(nav.velocity.x, 2) + Mathf.Pow(nav.velocity.z, 2));
        anim.SetFloat("Velocity", velocity);

        // If the player is close to the target and standing still call the arrived function.
        if (currentWork != null)
        {
            if (currentWork.GetTarget() != null)
            {
                if (currentWork.GetDistanceToTarget() < 1 && velocity < 0.1)
                {
                    currentWork.Arrived();
                }
            }
            else StartNextWork();
        }
        
    }

    // This function removes the current active work and replaces it with the next in the queue.
    public void StartNextWork()
    {
        // If the queue is not empty; set the current work to the next in the queue and start it.
        if (workQueue.Count > 0)
        {
            workQueue.Remove(currentWork.idInList);
            currentWork = workQueue[workQueue.Keys.Min()];

            if (currentWork.GetTarget() == null) StartNextWork();
            else currentWork.Init();

        } else
        {
            ResetQueue();
            Debug.Log("Work queue for: " + gameObject.name + " has finished.");
        }
    }
    
    // TODO: This is a stupid fix. Look at Work.idInList.
    private ushort i = 0;
    // Assigns the human to a job.
    public void AssignWork(Work work)
    {
        if (work == null) return;
        if (workQueue.ContainsValue(work)) return;

        work.idInList = i;
        workQueue.Add(i, work);

        // If it is the first job; assign it to the current active work and start it.
        if (workQueue.Count == 1)
        {
            currentWork = work;
            work.Init();
        }

        i++;
    }

    public void ResetQueue()
    {
        i = 0;
        currentWork = null;
        workQueue.Clear();

        Debug.Log("Reset queue for " + gameObject.name);
    }

    public Dictionary<ushort, Work> GetWorkQueue()
    {
        return workQueue;
    }

    public void AddItemToInventory(Item item)
    {
        currentItem = item;
    }

    // STATIC AREA

    // Currently finds the first human in the list which is not occupied.
    // TODO: Should upgrade to take into account distance and queue size.
    public static Human FindUnemployedHuman()
    {
        // Check if it has two or less in the queue.
        foreach (GameObject human in GameObject.FindGameObjectsWithTag("Human"))
        {
            if (human.GetComponent<Human>().GetWorkQueue().Count < 1)
            {
                return human.GetComponent<Human>();
            }
        }

        // Check if it has five or less in the queue.
        foreach (GameObject human in GameObject.FindGameObjectsWithTag("Human"))
        {
            if (human.GetComponent<Human>().GetWorkQueue().Count < 5)
            {
                return human.GetComponent<Human>();
            }
        }

        // Add the first human it finds
        foreach (GameObject human in GameObject.FindGameObjectsWithTag("Human"))
        {
            return human.GetComponent<Human>();
        }

        // Should never happen
        return null;
    }

    // Finds a random destination on the map
    // TODO: Not done.
    public static Vector3 FindRandomDestination()
    {
        return new Vector3(0, 0, 0);
    }
}