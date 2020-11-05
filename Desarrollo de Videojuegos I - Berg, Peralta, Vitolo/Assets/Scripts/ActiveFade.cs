using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFade : MonoBehaviour
{
   [SerializeField] private TextFader _textFader;
   
   private void Update()
   {
      if (GameManager.ActiveFadeIn)
      {
         _textFader.Fade();
         GameManager.ActiveFadeIn = false;
      }
      
      if (GameManager.ActiveFadeOut)
      {
         _textFader.Fade();
         GameManager.ActiveFadeOut = false;
      }
   }
}
