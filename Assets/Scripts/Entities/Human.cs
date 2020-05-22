﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Human : Entity
{

    // TODO: IMPORTANT: Queue system does not work properly yet.
    private Dictionary<int, Work> workQueue = new Dictionary<int, Work>();
    private Work currentWork;

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
        if (velocity < 0.2 && currentWork != null)
        {
            if (currentWork.GetDistanceToTarget() < 1)
            {
                currentWork.Arrived();
            }
        }
        
    }

    // This function removes the current active work and replaces it with the next in the queue.
    public void StartNextWork()
    {
        workQueue.Remove(currentWork.idInList);

        // If the queue is not empty; set the current work to the next in the queue.
        if (workQueue.Count > 0)
        {
            currentWork = workQueue[workQueue.Keys.Min()];
        } else
        {
            currentWork = null;
            Debug.Log("Work queue for: " + gameObject.name + " has finished");
        }
    }

    int i = 0;

    // Assigns the human to a job.
    public void AssignWork(Work work)
    {
        if (work == null) return;

        work.idInList = i;
        workQueue.Add(i, work);

        // If it is the first job; assign it to the current active work and start it.
        if (workQueue.Count == 1)
        {
            currentWork = work;
            work.Start();
        }
        i++;
    }

    // Currently finds the first human in the list which is not occupied.
    // TODO: Should upgrade to take into account distance.
    public static GameObject FindUnemployedHuman()
    {
        foreach (GameObject human in GameObject.FindGameObjectsWithTag("Human"))
        {
            if (human.GetComponent<Human>().workQueue.Count < 1)
            {
                return human;
            }
        }

        foreach (GameObject human in GameObject.FindGameObjectsWithTag("Human"))
        {
            if (human.GetComponent<Human>().workQueue.Count < 5)
            {
                return human;
            }
        }

        Debug.LogWarning("No humans available");
        return null;
    }

    // Finds a random destination on the map
    public static Vector3 FindRandomDestination()
    {
        return new Vector3(0, 0, 0);
    }
}