    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionables : MonoBehaviour
{
    [SerializeField] private TextFader _textFader;
    private float currentFadeTime;
    private float FadeSpawnTime = 2.5f;
    [HideInInspector] public bool activated = false;
    [HideInInspector] public bool isPickUP = false;
    
  private void Update()
    {
        if (isPickUP)
        {
            var sfxCollectable = GetComponent<AudioSource>();
            sfxCollectable.Play();
            _textFader.Fade();
            isPickUP = false;
            activated = true;
            GameManagerOLD.AddPoints(1);
        }
        
        if (activated)
        {
            FadeOnOff();
        }
    }
  
  private void FadeOnOff()
  { 
      if (currentFadeTime >= FadeSpawnTime)
      {
          currentFadeTime = 0f;
          _textFader.Fade();
          activated = false;
          Destroy(gameObject);
      }
      else
      {
          currentFadeTime += Time.deltaTime;
      }
  }
}