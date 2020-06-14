using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodItem : Item
{
    protected static new GameObject model = new GameObject("WoodItem");

    public WoodItem(short stackAmount)
    {
        stacksize = stackAmount;
    }
}