using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private float MoveSpeed = 15;
	private Interactable focus;
	public Human targetHuman;

	private void Start() {}

	private void Update()
	{
		// Get input
		float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * Time.deltaTime;
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		// Move
		transform.Translate(horizontal * MoveSpeed, 0, vertical * MoveSpeed, Space.World);
		transform.Translate(Vector3.forward * scroll, Space.Self);
	}

	public void CastRayAndAssignFocus(Vector3 mousePos)
	{
		// Find a human to do the job.
		targetHuman = Human.FindUnemployedHuman();

		// Initialize the ray
		Ray ray = GetComponent<Camera>().ScreenPointToRay(mousePos);
		RaycastHit hit;
		
		// Cast the ray
		if (Physics.Raycast(ray, out hit)) 
		{
			Interactable interactable = hit.collider.GetComponent<Interactable>();
			if (interactable != null) 
			{
				SetFocus(interactable);
			}
		}
	}

	public void SetFocus(Interactable newFocus)
	{
		if (newFocus != focus) 
		{
			if (focus != null) 
			{
				RemoveFocus();
			}
			focus = newFocus;

			targetHuman.FollowTarget(focus);
		}

		focus.OnFocused(targetHuman.transform);
	}

	public void RemoveFocus()
	{
		if (focus != null) 
		{
			focus.OnDefocused();
		}
		
		targetHuman.StopFollowingTarget();

		focus = null;

	}
}