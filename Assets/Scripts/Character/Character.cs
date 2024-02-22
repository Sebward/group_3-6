using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private void OnMouseOver()
    {
        Debug.Log("Mouse over person");

        //Input
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted with character");
        }
    }
}
