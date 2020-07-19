using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportWork : Work
{
    public TransportWork(GameObject target, Human human)
    {
        this.target = target;
        this.human = human;
    }

    public override void Arrived()
    {
        // Transfer items to inventory
        target.GetComponent<StorageBuilding>().items.Add(human.currentItem);
        human.currentItem = null;

        Finished();
    }
}
