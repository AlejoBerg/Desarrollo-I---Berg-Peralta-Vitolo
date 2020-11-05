using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableObject : MonoBehaviour
{
   public bool isPickeable = true;
   private Rigidbody rb;
   private bool active = true;
   [HideInInspector] public string tagName;
   public GameObject pickUpTextToShow;
   [SerializeField] private Parchments _parchments;
   [SerializeField] private Collectionables _collectionables;
   public AudioSource audioSFX = null;
   public GameObject mensajedefaltan;
   
   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag.Equals("DetectItem") && isPickeable)
      {
         other.GetComponentInParent<PickupObject>().itemToPickUp = this.gameObject;
         pickUpTextToShow.SetActive(true);
         tagName = tag;
      }
      
      if (other.gameObject.tag.Equals("DetectItem") && !isPickeable && GameManager.FragmentsNotes != 10)
      {
         if(tagName == "Poster"){mensajedefaltan.SetActive(true);}
         tagName = tag;
      }
      
   }
   
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.tag.Equals("Platforms"))
      {
         isPickeable = false;
         active = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.tag.Equals("DetectItem"))
      {
         other.GetComponentInParent<PickupObject>().itemToPickUp = null;
         pickUpTextToShow.SetActive(false);
         if(tagName == "Poster"){mensajedefaltan.SetActive(false);}
      }
   }
}
