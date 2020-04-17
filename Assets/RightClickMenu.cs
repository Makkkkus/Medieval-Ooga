using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : UI
{
    private Camera cam;
    private Vector3 MousePosWhenOpened;
    private void Start()
    {
        cam = Camera.main;
    }

    public void GatherButton()
    {
        if (Physics.Raycast(Camera.main.ScreenToWorldPoint(MousePosWhenOpened), Camera.main.transform.forward * 200, out RaycastHit rc))
        {
            Debug.Log("Hit " + rc.collider.gameObject.name);
            Debug.DrawLine(Camera.main.ScreenToWorldPoint(MousePosWhenOpened), rc.point, Color.red, 10);
        }
        CloseMenu();
    }

    public void OpenMenu()
    {
        MousePosWhenOpened = Input.mousePosition;
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