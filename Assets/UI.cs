using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            transform.GetChild(1).GetComponent<RightClickMenu>().OpenMenu();
    }
}
