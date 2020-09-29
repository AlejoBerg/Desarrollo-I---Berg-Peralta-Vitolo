using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  [SerializeField] public GameObject itemToPickUp;
  [SerializeField] public GameObject pickedObject;
  [SerializeField] public GameObject pickedObject2;
  [SerializeField] private Transform interactionZone;
  [SerializeField] private Transform backpackZone;
  [SerializeField] private PlayerController player;
  private bool test;
  private bool hudOff = false;

  private void Start()
  {
    player = GetComponent<PlayerController>();
  }

  private void Update()
  {
    //coleccionables
    
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
       pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Collectable")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        pickedObject = itemToPickUp;
        pickedObject.GetComponent<PickeableObject>().isPickeable = false;
        pickedObject.transform.position = new Vector3(-1,-1,-1);
        pickedObject.GetComponent<Rigidbody>().useGravity = false;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        itemToPickUp.GetComponent<Collectionables>().isPickUP = true;
      }
    }
    
     //antorcha
     
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject2 == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Antorch")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        pickedObject2 = itemToPickUp;
        pickedObject2.GetComponent<PickeableObject>().isPickeable = false;
        pickedObject2.transform.SetParent(backpackZone);
        pickedObject2.transform.position = backpackZone.position;
        pickedObject2.GetComponent<Rigidbody>().useGravity = false;
        pickedObject2.GetComponent<Rigidbody>().isKinematic = true;
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
      }
    }
   /* else if (pickedObject == null)
    {
      if (Input.GetKeyDown(KeyCode.F))
      {
        pickedObject2.GetComponent<PickeableObject>().isPickeable = true;
        pickedObject2.transform.SetParent(null);
        pickedObject2.GetComponent<Rigidbody>().useGravity = true;
        pickedObject2.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject2 = null;
      }
    }*/
    
    

    /// cualquier otro

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
    
    
    // pergaminos

    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Parchments") 
      { 
        if (Input.GetKeyDown(KeyCode.E))
        {
          pickedObject = itemToPickUp;
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<Parchments>().textToShow.SetActive(true);
          hudOff = true;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        }
      }
    else if (hudOff)
    {
      if (Input.GetKeyDown(KeyCode.Tab))
      { 
        pickedObject.GetComponent<Parchments>().textToShow.SetActive(false);
        Destroy(pickedObject);
        player.jumpActive = true;
      }
    }
  }
}
