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
    public event Action OnPuzzle2Victory;
  
     
 
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
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<MeshRenderer>().enabled = false;
          itemToPickUp.GetComponent<Collectionables>().isPickUP = true;
          GameManager.AddPoints(1);
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Fragments"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<MeshRenderer>().enabled = false;
          if (cont != 1) //ver
          {
            pickedObject.GetComponent<Fragments>().activeMision = true;
            cont++;
          }
          GameManager.AddFragment(1);
          StartCoroutine(Destroy());
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Poster"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
        
          GameManager.ActiveFade = true;
          if(GameManager.FragmentsNotes == 10 && cont != 2)
          {
            itemToPickUp.GetComponent<MeshRenderer>().material.mainTexture = itemToPickUp.GetComponent<Puzzle2>().puzzleEnd;
            itemToPickUp.GetComponent<Puzzle2>().FadeText();
            cont++;
            OnPuzzle2Victory?.Invoke();
          }
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Parchments"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
          pickedObject.GetComponent<Parchments>().activeType = true; 
          GameManager.AddParchment(1);
        }
        
        if (itemToPickUp.GetComponent<PickeableObject>().CompareTag("Rocks"))
        {
          pickedObject = itemToPickUp;
          if(pickedObject.GetComponent<AudioSource>() != null){pickedObject.GetComponent<PickeableObject>().audioSFX.Play();}
          pickedObject.GetComponent<PickeableObject>().isPickeable = false;
          itemToPickUp.GetComponent<PickeableObject>().pickUpTextToShow.SetActive(false);
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

    if (SceneManager.GetActiveScene().buildIndex == 2)
    {
      Destroy(torchObject);
    }
  }
  
  IEnumerator Destroy()
  {
    yield return new WaitForSeconds(2f);
    Destroy(pickedObject);
  }
}