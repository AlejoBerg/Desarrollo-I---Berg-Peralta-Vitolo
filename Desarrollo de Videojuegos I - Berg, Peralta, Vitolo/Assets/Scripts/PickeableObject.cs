using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableObject : MonoBehaviour
{
   public bool isPickeable = true;
   private Rigidbody rb;
   public string tagName;

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
      if (other.gameObject.tag.Equals("DetectItem"))
      {
         other.GetComponentInParent<PickupObject>().itemToPickUp = this.gameObject;
         tagName = tag;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.tag.Equals("DetectItem"))
      {
         other.GetComponentInParent<PickupObject>().itemToPickUp = null;
      }
   }
}
