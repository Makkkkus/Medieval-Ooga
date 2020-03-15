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
}
