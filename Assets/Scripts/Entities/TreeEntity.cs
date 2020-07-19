using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEntity : Entity
{
    public bool Cut(Human human)
    {
        human.currentItem = new WoodItem(1);
        Die();
        return true;
    }
}