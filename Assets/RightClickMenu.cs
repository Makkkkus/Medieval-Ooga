using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : UI
{
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    public void GatherButton()
    {
        Event e = Event.current;
        Ray ray = cam.ScreenPointToRay(e.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rc))
        {
            Debug.Log("Hit " + rc.collider);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 10);
        }
        CloseMenu();
    }

    public void OpenMenu()
    {
        Vector3 offset = new Vector3(125, -190);
        transform.position = Input.mousePosition;
        gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CloseMenu();
        }
    }
}