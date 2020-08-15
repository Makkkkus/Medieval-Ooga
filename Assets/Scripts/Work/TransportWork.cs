using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportWork : Work
{
	private bool TransportFrom;
	public TransportWork(GameObject target, Human human, bool TransportFrom)
	{
		this.target = target;
		this.human = human;
		this.TransportFrom = TransportFrom;
	}

	public override void Arrived()
	{
		if (TransportFrom)
		{
		
		} else
		{
		// Transfer items to inventory
		target.GetComponent<StorageBuilding>().items.Add(human.currentItem);
		human.currentItem = null;
		
		Finished();
		}
	}
}
