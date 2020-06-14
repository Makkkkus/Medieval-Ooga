using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingWork : Work
{
    public ChoppingWork(GameObject target, GameObject human)
    {
        this.target = target;
        this.human = human;
    }

    public override void Arrived() 
    {
        // Cut the tree
        target.GetComponent<TreeEntity>().Cut(human.GetComponent<Human>());
        Debug.Log("Executed: ChoppingWork.Arrived()");

        Finished();
    }
}
