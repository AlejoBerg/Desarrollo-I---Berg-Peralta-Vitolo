using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  [SerializeField] private Transform interactionZone;
  [SerializeField] private Transform backpackZone;
  [HideInInspector] public GameObject itemToPickUp;
  [HideInInspector] public GameObject pickedObject;
  [HideInInspector] public GameObject torchObject;
  [SerializeField] private Vector3 torchPosition;
  [SerializeField] private Vector3 torchAngleRotation;
 
  private void Update()
  {
    //coleccionables
    
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
       pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Collectable")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        ThingsToDo();
        PlayerController.PickUpTorch = true;
        StartCoroutine(pickItems());
        pickedObject.transform.position = new Vector3(-1,-1,-1);
        itemToPickUp.GetComponent<Collectionables>().isPickUP = true;
      }
    }
    
     //antorcha
     
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        torchObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Torch")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        PlayerController.PickUpTorch = true;
        StartCoroutine(pickTorch());
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
        PlayerController.PickUpTorch = true;
        StartCoroutine(pickItems());
        pickedObject.GetComponent<Parchments>().activeType = true;
      }
    }

    // rocas

    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        pickedObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Rocks")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        ThingsToDo();
        PlayerController.PickUpItem = true;
        PlayerController.PlayerSpeed = 1f;
        pickedObject.transform.SetParent(interactionZone);
        pickedObject.transform.position = interactionZone.position;
        if(pickedObject.GetComponent<Rigidbody>() != null){
          pickedObject.GetComponent<Rigidbody>().useGravity = false;
          pickedObject.GetComponent<Rigidbody>().isKinematic = true;}
        if(pickedObject.GetComponent<BoxCollider>() != null){pickedObject.GetComponent<BoxCollider>().enabled = false;}
      }
    } 
    else if (pickedObject != null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
          pickedObject.GetComponent<PickeableObject>().isPickeable = true;
          pickedObject.transform.SetParent(null);
          PlayerController.PlayerSpeed = 1.5f;
          if(pickedObject.GetComponent<Rigidbody>() != null){
          pickedObject.GetComponent<Rigidbody>().useGravity = true;
          pickedObject.GetComponent<Rigidbody>().isKinematic = false;}
          if(pickedObject.GetComponent<BoxCollider>() != null){pickedObject.GetComponent<BoxCollider>().enabled = true;}
          pickedObject = null;
          PlayerController.PickUpItem = false;
      }
    }

    void ThingsToDo()
    {
      pickedObject = itemToPickUp;
      if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
      pickedObject.GetComponent<PickeableObject>().isPickeable = false;
      itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
    }
    
    IEnumerator pickTorch()
    {
        torchObject = itemToPickUp;
        torchObject.GetComponent<PickeableObject>().audioSFX.Play();
        torchObject.GetComponent<PickeableObject>().isPickeable = false;
        yield return new WaitForSeconds(0.2f);
        PlayerController.PickUpTorch = false;
        torchObject.transform.SetParent(backpackZone);
        torchObject.transform.localRotation = Quaternion.Euler(torchAngleRotation);
        torchObject.transform.localPosition = torchPosition;
    }
    
    IEnumerator pickItems()
    {
      yield return new WaitForSeconds(0.2f);
      PlayerController.PickUpTorch = false;
    }
  }
}