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