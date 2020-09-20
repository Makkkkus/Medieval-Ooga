using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;
	
	public GameObject ItemDropPrefab;
	public int space = 20;
	public List<Item> items = new List<Item>();


	public bool Add(Item item) 
	{
		if (!item.isDefaultItem) 
		{
			if (items.Count >= space) 
			{
				return false;
			}
			items.Add(item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}
		return true;
	}

	public void Remove(Item item) 
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	//public void Drop(Item item, Transform position) 
	//{
	//	Remove(item);
	//	ItemPickup droppedItem = Instantiate(ItemDropPrefab, position.position, position.rotation).GetComponent<ItemPickup>();
	//	Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
	//	droppedItem.item = item;
	//	rb.AddForce(position.rotation.eulerAngles.normalized * 5 + Vector3.one);
//
	//	droppedItem = null;
	//	rb = null;
	//}

	public static Inventory instance;
	private void Awake()
	{
		if (instance != null) 
		{
			Debug.LogWarning("More than one inventory instances found");
			return;
		}
		instance = this;
	}
}
