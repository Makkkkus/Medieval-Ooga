using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : UI
{
    private Vector3 MousePosWhenOpened;

    // This code is executed when clicking the gather button.
    // This will find a unemployed human and set him to gather the resource
    public void GatherButton()
    {
        MousePosWhenOpened.z = 1;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(MousePosWhenOpened), out RaycastHit rc))
        {
            Debug.DrawLine(Camera.main.ScreenPointToRay(MousePosWhenOpened).origin, rc.point, Color.red, 10);
            GameObject human = Human.FindUnemployedHuman();
            if (!(human == null)) {
                human.GetComponent<Human>().Gather(rc.collider.gameObject);
            } else
            {
                Debug.Log("No human availabale");
            }
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