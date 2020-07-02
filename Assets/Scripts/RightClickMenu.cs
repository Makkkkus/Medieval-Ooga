using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private Vector3 MousePosWhenOpened;

    // This code is executed when clicking the assign button.
    // This will find a unemployed human and set him to gather the resource.
    // TODO: Move this code somewhere else. Rays should not be cast in a method inside a UI class.
    public void AssignButton()
    {
        CameraController.CastRayAndAssignWork(MousePosWhenOpened);
        CloseMenu();
    }

    // Opens the menu, and moves it to the mouse position.
    public void OpenMenu()
    {
        MousePosWhenOpened = Input.mousePosition;
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