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
  
    private int cont = 0;
    private int cont2 = 0;
 
  private void Update()
  {
    if (itemToPickUp != null && itemToPickUp.GetComponent<PickeableObject>().isPickeable == true  && pickedObject == null)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Collectable"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<MeshRenderer>().enabled = false;
          itemToPickUp.GetComponent<Collectionables>().isPickUP = true;
          GameManager.AddPoints(1);
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Fragments"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<MeshRenderer>().enabled = false;
          pickedObject.GetComponent<Fragments>().isPickup = true;
          if (cont != 1)
          {
            GameManager.ActiveFade = true;
            pickedObject.GetComponent<Fragments>().activeMision = true;
            cont++;
          }
          GameManager.AddFragment(1);
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Items3D"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<MeshRenderer>().enabled = false;
          pickedObject.GetComponent<ItemsPuzzle2LVL3>().activeMision = true;
          
          if (cont2 != 1)
          {
            GameManager.ActiveFade = true;
            cont2++;
          }
          GameManager.AddItems2(1);
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("ItemsBridge"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<MeshRenderer>().enabled = false;
          /*pickedObject.GetComponent<PickupItemsAndShowTexts>().isPickup = true;
          if (cont != 1)
          {
            GameManager.ActiveFade = true;
            pickedObject.GetComponent<PickupItemsAndShowTexts>().activeMision = true;
            cont++;
          }*/
          GameManager.AddItems(1);
          StartCoroutine(ItemsDestroy());
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Bridge"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          Puzzle4.CanRepair = true;
          pickedObject = null;
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Poster"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        
          if(GameManager.FragmentsNotes == 10 && cont != 2)
          {
            itemToPickUp.GetComponent<MeshRenderer>().material.mainTexture = itemToPickUp.GetComponent<Puzzle2>().puzzleEnd;
            itemToPickUp.GetComponent<Puzzle2>().FadeText();
            GameManager.ActiveFade = true;
            cont++;
          }

          if (itemToPickUp.GetComponent<Puzzle2>().canShowAgain)
          {
            itemToPickUp.GetComponent<Puzzle2>().FadeText2();
            itemToPickUp.GetComponent<Puzzle2>().canShowAgain = false;
            pickedObject = null;
          }
        }
        
          if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Parchments"))
          {
            pickedObject = itemToPickUp;
            if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
            pickedObject.GetComponent<PickeableObject>().isPickeable = false;
            pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
            pickedObject.GetComponent<Parchments>().activeType = true; 
            GameManager.AddParchment(1);
          }
        
          if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Rocks"))
          {
            pickedObject = itemToPickUp;
            if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
            pickedObject.GetComponent<PickeableObject>().isPickeable = false;
            pickedObject.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
            player.pickUpItem = true;
            player.ChangeWalkPlayerSpeed(1f);
            pickedObject.transform.SetParent(interactionZone);
            pickedObject.transform.position = interactionZone.position;
            if(pickedObject.GetComponent<Rigidbody>() != null){
              pickedObject.GetComponent<Rigidbody>().useGravity = false;
              pickedObject.GetComponent<Rigidbody>().isKinematic = true;
              pickedObject.GetComponent<BoxCollider>().enabled = false;
            }
          }
        }
      }
      else if (pickedObject != null)
      {
        if (Input.GetKeyDown(KeyCode.E))
        {

          if (pickedObject.CompareTag("Rocks"))
          {
           pickedObject.transform.localPosition = new Vector3(0,0,1);
           pickedObject.GetComponent<PickeableObject>().isPickeable = true;
          }
          pickedObject.transform.SetParent(null);
          player.ChangeWalkPlayerSpeed(1.5f);
         if(pickedObject.GetComponent<Rigidbody>() != null){
          pickedObject.GetComponent<Rigidbody>().useGravity = true;
          pickedObject.GetComponent<Rigidbody>().isKinematic = false;}
         if(pickedObject.GetComponent<BoxCollider>() != null){pickedObject.GetComponent<BoxCollider>().enabled = true;}
          pickedObject = null;
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
        player.pickUpTorch = false;
        torchObject.transform.SetParent(backpackZone);
        torchObject.transform.localRotation = Quaternion.Euler(torchAngleRotation);
        torchObject.transform.localPosition = torchPosition;
        yield return null;
    }
    
    IEnumerator ItemsDestroy()
    {
      yield return new WaitForSeconds(1f);
      Destroy(pickedObject.gameObject);
    }

    if (SceneManager.GetActiveScene().buildIndex == 2)
    {
      Destroy(torchObject);
    }
  }
}