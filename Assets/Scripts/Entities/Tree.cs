using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Entity
{
    private void Start()
    {
        maxAge = 50;
    }

    public bool Cut(Human human)
    {
        Debug.Log("Cut the tree!");
        Die();
        return true;
    }
}