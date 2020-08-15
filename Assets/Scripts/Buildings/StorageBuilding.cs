using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBuilding : Building
{
	public List<Item> items;

	// STATIC AREA

	/// <summary>
	/// Finds the closest storage object for a human
	/// </summary>
	/// <param name="human">What human executed this command?</param>
	/// <returns>The closest storage</returns>
	public static GameObject FindClosestStorage(Human human)
	{
		return GameObject.FindGameObjectWithTag("Storage");
	}
}
