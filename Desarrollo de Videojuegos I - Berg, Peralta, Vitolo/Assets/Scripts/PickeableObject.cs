using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableObject : MonoBehaviour
{
   public bool isPickeable = true;
   private Rigidbody rb;
   private bool active = true;
   public string tagName;
   [SerializeField] public GameObject pickUpTextToShow;
   [SerializeField] public Parchments _parchments;
   [SerializeField] private Collectionables _collectionables;
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
      }
   }
}
