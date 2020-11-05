using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFade : MonoBehaviour
{
   [SerializeField] private TextFader _textFader;
   
   private void Update()
   {
      if (GameManager.ActiveFade)
      {
         _textFader.Fade();
         GameManager.ActiveFade = false;
      }
      
     /* if (GameManager.ActiveFadeOut)
      {
         _textFader.Fade();
         GameManager.ActiveFadeOut = false;
      }*/
   }
}
