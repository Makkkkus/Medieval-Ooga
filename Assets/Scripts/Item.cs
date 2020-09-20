using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Farming Game/Item")]
public class Item : ScriptableObject
{
	new public string name = "Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;
	public int amount = 1;
}
