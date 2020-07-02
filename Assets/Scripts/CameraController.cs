using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float MoveSpeed = 15;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(horizontal * MoveSpeed, 0, vertical * MoveSpeed, Space.World);
        transform.Translate(Vector3.forward * scroll, Space.Self);
    }


    // This will cast a ray and find a unemployed human and set him to gather the resource the ray hit.
    public static void CastRayAndAssignWork(Vector3 mousePos)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out RaycastHit rc))
        {
            Debug.DrawLine(Camera.main.ScreenPointToRay(mousePos).origin, rc.point, Color.red, 10);

            GameObject human = Human.FindUnemployedHuman();

            // THIS ASSIGNS HUMANS WORK.
            // TODO: Make this cleaner.
            human.GetComponent<Human>().AssignWork(Work.FindCorrectWork(rc.collider.gameObject, human));
        }
    }
}