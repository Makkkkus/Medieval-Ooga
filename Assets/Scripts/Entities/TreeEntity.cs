using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEntity : Entity
{
    public bool Cut(Human human)
    {
        Debug.Log("Cut the tree!");
        human.AddItemToInventory(new WoodItem(1));
        Die();
        return true;
    }
}