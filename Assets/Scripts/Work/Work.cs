using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Work
{
    protected GameObject target;
    protected GameObject human;

    // TODO: This is stupid.
    public ushort idInList;

    // Moves the player to the work.
    public virtual void Start()
    {
        Debug.Log("Executed: Work.Start()");

        // Sets the destination for the human.
        NavMeshAgent nav = human.GetComponent<NavMeshAgent>();
        nav.SetDestination(target.transform.position);
    }

    // Called when arrived. Does the actual work.
    public virtual void Arrived()
    {
        Debug.Log("Executed: Work.Arrived()");


        // This has to be at the end of the function.
        Finished();
    }

    // Called after the work is done.
    public virtual void Finished()
    {
        Debug.Log("Executed: Work.Finished()");

        // Starts the next work in the queue.
        human.GetComponent<Human>().StartNextWork();
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
}
