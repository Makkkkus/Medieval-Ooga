using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickMenu : MonoBehaviour
{
    public void GatherButton()
    {
        gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        Vector3 offset = new Vector3(-165, 250);
        transform.position = Input.mousePosition - offset;
        gameObject.SetActive(true);
    }
}
