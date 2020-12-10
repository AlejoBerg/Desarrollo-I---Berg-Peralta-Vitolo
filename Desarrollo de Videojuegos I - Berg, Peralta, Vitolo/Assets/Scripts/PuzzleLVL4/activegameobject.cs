using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activegameobject : MonoBehaviour
{
   public GameObject scriptPuzzle6;
   public GameObject camera;
   [HideInInspector]public bool startPuzzle = false;
   public Camera test;

   private void Update()
   {
      if (startPuzzle)
      {
         StartCoroutine(Delay());
      }
   }

   IEnumerator Delay()
   {
      camera.SetActive(true);
      test.orthographicSize = 1.52f;
      yield return new WaitForSeconds(1f);
      scriptPuzzle6.SetActive(true);
      startPuzzle = false;
      yield return null;
   }
}
