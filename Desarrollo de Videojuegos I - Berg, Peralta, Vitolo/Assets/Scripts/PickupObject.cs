using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  public GameObject itemToPickUp;
  public GameObject pickedObject;
  [SerializeField] private Transform interactionZone;
  [SerializeField] private PlayerController player;
  [SerializeField] private Parchments _parchments;
  private bool hudOff = false;

  private void Start()
  {
    player = GetComponent<PlayerController>();
  }

  private void Update()
  {
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName != "Parchments")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        pickedObject = itemToPickUp;
        pickedObject.GetComponent<PickeableObject>().isPickeable = false;
        pickedObject.transform.SetParent(interactionZone);
        pickedObject.transform.position = interactionZone.position;
        pickedObject.GetComponent<Rigidbody>().useGravity = false;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
      }
    }
    else if (pickedObject != null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        pickedObject.GetComponent<PickeableObject>().isPickeable = true;
        pickedObject.transform.SetParent(null);
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject = null;
      }
    }

    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Parchments") 
    { 
      if (Input.GetKeyDown(KeyCode.E))
      {
        pickedObject = itemToPickUp;
        pickedObject.GetComponent<PickeableObject>().isPickeable = false;
        _parchments.textToShow.SetActive(true);
        hudOff = true;
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
      }
    }
    else if (hudOff)
    {
      if (Input.GetKeyDown(KeyCode.Tab))
      { 
        _parchments.textToShow.SetActive(false);
        Destroy(pickedObject);
        player.jumpActive = true;
      }
    }
  }
}
