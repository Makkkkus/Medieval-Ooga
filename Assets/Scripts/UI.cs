using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject RightClickMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            RightClickMenu.GetComponent<RightClickMenu>().OpenMenu();
    }
}