using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableObject : MonoBehaviour
{
   public bool isPickeable = true;

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag.Equals("DetectItem"))
      {
         other.GetComponentInParent<PickupObject>().itemToPickUp = this.gameObject;
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
