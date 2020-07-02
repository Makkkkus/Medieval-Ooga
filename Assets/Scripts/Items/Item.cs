using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    protected const short maxStack = 999;

    protected static GameObject model;
    protected short stacksize;

    public short Amount {
        get => stacksize;
    }
    
    public void Drop(Vector3 position)
    {
        GameObject.Instantiate(model, position, Quaternion.Euler(0, 0, 0));
    }

    public void AddToStack(short amount)
    {
        if (stacksize <= maxStack)
        {
            stacksize += amount;
        }
        else
        {
            stacksize = maxStack;
            Debug.LogWarning("Item.AddToStack(): Stack is full. Some items may have dissappared.");
        }
    }
}