using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : UI
{
    private Vector3 MousePosWhenOpened;

    // This code is executed when clicking the assign button.
    // This will find a unemployed human and set him to gather the resource.
    public void AssignButton()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(MousePosWhenOpened), out RaycastHit rc))
        {
            Debug.DrawLine(Camera.main.ScreenPointToRay(MousePosWhenOpened).origin, rc.point, Color.red, 10);

            GameObject human = Human.FindUnemployedHuman();

            // THIS ASSIGNS HUMANS WORK.
            // TODO: Make this cleaner.
            human.GetComponent<Human>().AssignWork(Work.FindCorrectWork(rc.collider.gameObject, human));
        }
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