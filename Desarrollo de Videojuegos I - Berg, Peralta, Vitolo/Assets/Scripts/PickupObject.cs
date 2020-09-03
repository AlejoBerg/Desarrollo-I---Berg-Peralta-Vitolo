using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  public GameObject itemToPickUp;
  public GameObject PickedObject;
  public Transform interactionZone; // donde quiero que deje el objeto

  private void Update()
  {
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        PickedObject == null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        PickedObject = itemToPickUp;
        PickedObject.GetComponent<PickeableObject>().isPickeable = false;
        PickedObject.transform.SetParent(interactionZone);
        PickedObject.transform.position = interactionZone.position;
        PickedObject.GetComponent<Rigidbody>().useGravity = false;
        PickedObject.GetComponent<Rigidbody>().isKinematic = true;
      }
    }
    else if (PickedObject != null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        PickedObject.GetComponent<PickeableObject>().isPickeable = true;
        PickedObject.transform.SetParent(null);
        PickedObject.GetComponent<Rigidbody>().useGravity = true;
        PickedObject.GetComponent<Rigidbody>().isKinematic = false;
        PickedObject = null;
      }
    }
  }
}
