using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
  [SerializeField] private Transform interactionZone;
  [SerializeField] private Transform backpackZone;
  [HideInInspector] public GameObject itemToPickUp;
  [HideInInspector] public GameObject pickedObject;
  [HideInInspector] public GameObject torchObject;
  [SerializeField] private PlayerController player;
  [SerializeField] private Vector3 torchPosition;
  [SerializeField] private Vector3 torchAngleRotation;
 
  private void Update()
  {
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true && pickedObject == null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Collectable"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          itemToPickUp.GetComponent<Collectionables>().isPickUP = true;
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Parchments"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<Parchments>().activeType = true; 
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Rocks"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          //PlayerController.PickUpItem = true;
          player.pickUpItem = true;
          player.ChangeWalkPlayerSpeed(1f);
          pickedObject.transform.SetParent(interactionZone);
          pickedObject.transform.position = interactionZone.position;
          if(pickedObject.GetComponent<Rigidbody>() != null){
            pickedObject.GetComponent<Rigidbody>().useGravity = false;
            pickedObject.GetComponent<Rigidbody>().isKinematic = true;}
          if(pickedObject.GetComponent<BoxCollider>() != null){pickedObject.GetComponent<BoxCollider>().enabled = false;}
        }
      }
    }
    else if (pickedObject != null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        pickedObject.GetComponent<PickeableObject>().isPickeable = true;
        if(pickedObject.CompareTag("Rocks")){pickedObject.transform.localPosition = new Vector3(0,0,1);}
        pickedObject.transform.SetParent(null);
        player.ChangeWalkPlayerSpeed(1.5f);
        if(pickedObject.GetComponent<Rigidbody>() != null){
          pickedObject.GetComponent<Rigidbody>().useGravity = true;
          pickedObject.GetComponent<Rigidbody>().isKinematic = false;}
        if(pickedObject.GetComponent<BoxCollider>() != null){pickedObject.GetComponent<BoxCollider>().enabled = true;}
        pickedObject = null;
        //PlayerController.PickUpItem = false;
        player.pickUpItem = false;
      }
    }

    //Pick de antorcha separado porque usa otro objeto como punto de comparación 
     
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true &&
        torchObject == null && itemToPickUp.GetComponent<PickeableObject>().tagName == "Torch")
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        StartCoroutine(pickTorch());
      }
    }
  
    IEnumerator pickTorch()
    {
        torchObject = itemToPickUp;
        torchObject.GetComponent<PickeableObject>().audioSFX.Play();
        torchObject.GetComponent<PickeableObject>().isPickeable = false;
        //PlayerController.PickUpTorch = false;
        player.pickUpTorch = false;
        torchObject.transform.SetParent(backpackZone);
        torchObject.transform.localRotation = Quaternion.Euler(torchAngleRotation);
        torchObject.transform.localPosition = torchPosition;
        yield return null;
    }

    if (SceneManager.GetActiveScene().buildIndex == 1)
    {
      Destroy(torchObject);
      Destroy(pickedObject);
      torchObject = null;
      pickedObject = null;
    }
  }
}