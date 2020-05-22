using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Work
{
    protected GameObject target;
    protected GameObject human;
    public int idInList;

    // Will return the correct type of work from the tag of the target.
    public static Work FindCorrectWork(GameObject target, GameObject human) 
    {
        switch (target.tag)
        {
            case "Tree":
                return new ChoppingWork(target, human);

            case "Farm":
                break;
        }

        return null;
    }

    // Moves the player to the work.
    public virtual void Start() 
    {
        // Sets the destination for the human.
        NavMeshAgent nav = human.GetComponent<NavMeshAgent>();
        nav.SetDestination(target.transform.position);
        Debug.Log("Executed: Work.Start()");
    }

    // Called when arrived. Does the actual work.
    public virtual void Arrived()
    {
        Debug.Log("Executed: Work.Arrived()");
        Finished();
    }

    // Called after the work is done.
    public virtual void Finished()
    {
        Debug.Log("Executed: Work.Finished()");

        // Starts the next work in the queue.
        human.GetComponent<Human>().StartNextWork();
    }

    public float GetDistanceToTarget()
    {
        return Vector3.Distance(human.transform.position, target.transform.position);
    }
}
