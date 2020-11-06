using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCameraHide : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        { 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        { 
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}