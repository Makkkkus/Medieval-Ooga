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
        base.Arrived();

        // Cut the tree
        target.GetComponent<Tree>().Cut(human.GetComponent<Human>());
        Debug.Log("Executed: ChoppingWork.Arrived()");
    }
}
