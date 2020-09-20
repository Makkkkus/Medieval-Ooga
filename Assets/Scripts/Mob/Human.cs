using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Human : Entity
{
	public Item currentItem;
	private NavMeshAgent nav;
	private Animator anim;
	private Transform moveTarget;

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

		//If the player is close to the target and standing still call the arrived function.
		//if (currentWork != null)
		//{
		//	if (currentWork.GetTarget() != null)
		//	{
		//		if (currentWork.GetDistanceToTarget() < 1 && velocity < 0.1)
		//		{
		//			currentWork.Arrived();
		//		}
		//	}
		//	else StartNextWork();
		//}
		
	}

	public void MoveToPoint(Transform point)
	{
		nav.SetDestination(point.position);
	}

	public void FollowTarget(Interactable target)
	{
		moveTarget = target.interactionTransform;

		nav.stoppingDistance = target.radius * 0.8f;
		nav.updateRotation = false;
		
		StartCoroutine("FollowTargetCoroutine");
	}

	private IEnumerator FollowTargetCoroutine()
	{
		for (;;) // Infinite loop
		{
			Vector3 direction = (moveTarget.position - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

			transform.rotation = lookRotation;
			nav.SetDestination(moveTarget.position);
			yield return new WaitForSeconds(0.1f); // Pause for 200ms
		}
	}

	public void StopFollowingTarget()
	{
		nav.stoppingDistance = 0;
		nav.updateRotation = true;

		moveTarget = null;

		StopCoroutine("FollowTargetCoroutine");
	}

	//This function removes the current active work and replaces it with the next in the queue.
	//public void StartNextWork()
	//{
	//	if (currentItem != null)
	//	{
	//		ResetQueue();
	//		AssignWork(Work.FindCorrectWork(StorageBuilding.FindClosestStorage(this), this));
	//		Debug.Log(gameObject.name + " has full inventory; job not done.");
	//		return;
	//	}

	//	// If the queue is not empty; set the current work to the next in the queue and start it.
	//	if (workQueue.Count > 0)
	//	{
	//		workQueue.Remove(currentWork.idInList);
	//		currentWork = workQueue[workQueue.Keys.Min()];

	//		if (currentWork.GetTarget() == null) StartNextWork();
	//		else currentWork.Init();
	//	} else
	//	{
	//		ResetQueue();
	//		Debug.Log("Work queue for: " + gameObject.name + " has finished.");
	//	}
	//}
	
	// TODO: This is a stupid fix. Look at Work.idInList.
	//private ushort i = 0;
	// Assigns the human to a job.
	// Returns true if the work has been queued.
	//public bool AssignWork(Work work)
	//{
	//	if (work == null) return false;
	//	if (workQueue.ContainsValue(work)) return false;
	//	if (currentItem != null) return false;

	//	work.idInList = i;
	//	workQueue.Add(i, work);

	//	// If it is the first job; assign it to the current active work and start it.
	//	if (workQueue.Count == 1)
	//	{
	//		currentWork = work;
	//		work.Init();
	//	}

	//	i++;
	//	return true;
	//}

	///// <summary>
	///// Resets the queue of the human this function is called on.
	///// </summary>
	//public void ResetQueue()
	//{
	//	i = 0;
	//	currentWork = null;
	//	workQueue.Clear();

	//	Debug.Log("Reset queue for " + gameObject.name);
	//}
	
	// STATIC AREA

	private static System.Random random = new System.Random();

	// Finds a random human in the list which is not occupied.
	// TODO: Should upgrade to take into account distance.
	public static Human FindUnemployedHuman()
	{
		GameObject[] humans = GameObject.FindGameObjectsWithTag("Human"); // TODO: Should create a delegate to store and update this for performance reasons.
		humans = humans.OrderBy(x => random.Next()).ToArray(); // Randomizes the list
		
		// Add the first human it finds
		foreach (GameObject human in humans)
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