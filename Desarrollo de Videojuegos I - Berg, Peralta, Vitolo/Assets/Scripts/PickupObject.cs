using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  [SerializeField] private Transform interactionZone;
  [SerializeField] private Transform backpackZone;
  [SerializeField] private PlayerController player;
  [HideInInspector] public GameObject itemToPickUp;
  [HideInInspector] public GameObject pickedObject;
  [HideInInspector] public GameObject torchObject;
  [SerializeField] private Vector3 torchPosition;
  [SerializeField] private Vector3 torchAngleRotation;
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
        ThingsToDo();
        pickedObject.transform.position = new Vector3(-1,-1,-1);
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
        torchObject.GetComponent<PickeableObject>().audioSFX.Play();
        torchObject.GetComponent<PickeableObject>().isPickeable = false;
        torchObject.transform.SetParent(backpackZone);
        torchObject.transform.localRotation = Quaternion.Euler(torchAngleRotation);
        torchObject.transform.localPosition = torchPosition;
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
      }
    }
    
    // pergaminos

    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Parchments") 
    { 
      if (Input.GetKeyDown(KeyCode.E))
      {
        ThingsToDo();
        player.jumpActive = true;
        pickedObject.GetComponent<Parchments>().activeType = true;
      }
    }

    /// cualquier otro

    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName != "Parchments")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        ThingsToDo();
        pickedObject.transform.SetParent(interactionZone);
        pickedObject.transform.position = interactionZone.position;
        if(pickedObject.GetComponent<Rigidbody>() != null){
          pickedObject.GetComponent<Rigidbody>().useGravity = false;
          pickedObject.GetComponent<Rigidbody>().isKinematic = true;}
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

    void ThingsToDo()
    {
      pickedObject = itemToPickUp;
      if(pickedObject.GetComponent<AudioClip>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
      pickedObject.GetComponent<PickeableObject>().isPickeable = false;
      itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
    }
  }
}