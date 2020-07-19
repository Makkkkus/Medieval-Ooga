using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Work
{
    protected GameObject target;
    protected Human human;

    // TODO: This is stupid.
    public ushort idInList;

    // Moves the player to the work.
    public virtual void Init()
    {
        // Sets the destination for the human.
        NavMeshAgent nav = human.GetComponent<NavMeshAgent>();
        nav.SetDestination(target.transform.position);
    }

    // Called when arrived. Does the actual work.
    public virtual void Arrived()
    {
        // This has to be at the end of the function.
        Finished();
    }

    // Called after the work is done.
    public virtual void Finished()
    {
        // Starts the next work in the queue.
        human.StartNextWork();
    }

    // Used in the update method of Human
    public float GetDistanceToTarget()
    {
        if (target == null) return 0;
        return Vector3.Distance(human.transform.position, target.transform.position);
    }

    public GameObject GetTarget()
    {
        return target;
    }

    // STATIC AREA

    // Will return the correct type of work from the tag of the target.
    // This method creates the work objects.
    public static Work FindCorrectWork(GameObject target, Human human)
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
}
