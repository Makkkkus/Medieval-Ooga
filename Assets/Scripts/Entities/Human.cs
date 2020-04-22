using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : Entity
{
    public bool Occupied = false;

    private NavMeshAgent nav;

    private void Start()
    {
        maxAge = 100;
        nav = GetComponent<NavMeshAgent>();
        humans.Add(gameObject);
    }

    // Finds a random destination on the map
    public Vector3 FindRandomDestination()
    {
        return new Vector3(0, 0, 0);
    }

    // Assigns the human to a job.
    public void Gather(GameObject gather)
    {
        Occupied = true;
        nav.SetDestination(gather.transform.position);
    }

    // List of all humans in the scene.
    private static List<GameObject> humans = new List<GameObject>();

    // Currently finds the first human in the list which is not occupied.
    // TODO: Should upgrade to take into account distance.
    public static GameObject FindUnemployedHuman()
    {
        //for (int i = 0; i <= humans.Count; i++)
        foreach (GameObject human in humans)
        {
            if (!human.GetComponent<Human>().Occupied)
            {
                return human;
            }
        }
        Debug.LogWarning("No humans available");
        return null;
    }
}