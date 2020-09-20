using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;	
	bool isFocus = false;
	Transform player;

	private bool hasInteracted = false;

	public virtual void Interact() {}			// Overwridden in sub-classes.
	public virtual void EnableIndicator() {}	// Overwridden in sub-classes.
	public virtual void DisableIndicator() {}	// Overwridden in sub-classes.

	private void Update()
	{
		if (isFocus) 
		{
			if (!hasInteracted) 
			{
				float distance = Vector3.Distance(player.position, interactionTransform.position);
				if (distance <= radius) 
				{
					Interact();
					hasInteracted = true;
				}
			}
		}
	}

	// This focuses a player on this object.
	public void OnFocused(Transform playerTransform) 
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
		EnableIndicator();
	}

	// This unfocuses this instance.
	public void OnDefocused()
	{
		isFocus = false;
		player = null;
		DisableIndicator();
	}

	// Draws a circle around the object in the editor
	private void OnDrawGizmosSelected() 
	{
		if (interactionTransform == null) 
		{
			interactionTransform = transform;
		}

		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
}
