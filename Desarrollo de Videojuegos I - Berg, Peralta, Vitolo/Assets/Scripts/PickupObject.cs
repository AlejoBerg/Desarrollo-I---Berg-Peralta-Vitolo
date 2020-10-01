using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  [SerializeField] public GameObject itemToPickUp;
  [SerializeField] public GameObject pickedObject;
  [SerializeField] public GameObject torchObject;
  [SerializeField] private Transform interactionZone;
  [SerializeField] private Transform backpackZone;
  [SerializeField] private PlayerController player;
  
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
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        itemToPickUp.GetComponent<Collectionables>().isPickUP = true;
      }
    }
    
     //antorcha
     
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        torchObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Antorch")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        torchObject = itemToPickUp;
        torchObject.GetComponent<PickeableObject>().isPickeable = false;
        torchObject.transform.SetParent(backpackZone);
        torchObject.transform.position = backpackZone.position;
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
      }
    }

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
        if(pickedObject.GetComponent<Rigidbody>() != null){
        pickedObject.GetComponent<Rigidbody>().useGravity = false;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;}
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
      }
    } 
    else if (pickedObject != null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
          pickedObject.GetComponent<PickeableObject>().isPickeable = true;
          pickedObject.transform.SetParent(null);
          if(pickedObject.GetComponent<Rigidbody>() != null){
          pickedObject.GetComponent<Rigidbody>().useGravity = true;
          pickedObject.GetComponent<Rigidbody>().isKinematic = false;}
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
          player.jumpActive = true;
          pickedObject.GetComponent<Parchments>().activeType = true;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        }
      }
  }
}