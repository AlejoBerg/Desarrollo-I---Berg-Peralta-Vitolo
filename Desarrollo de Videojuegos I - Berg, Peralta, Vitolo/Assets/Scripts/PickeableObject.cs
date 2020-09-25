using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableObject : MonoBehaviour
{
   public bool isPickeable = true;
   private Rigidbody rb;
   public string tagName;
   [SerializeField] private GameObject pickUpTextToShow;
   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
      if (rb.IsSleeping())
      {
         rb.WakeUp();
      }
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
