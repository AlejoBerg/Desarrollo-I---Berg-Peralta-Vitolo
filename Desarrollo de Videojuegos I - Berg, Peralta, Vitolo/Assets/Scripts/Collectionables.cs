    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionables : MonoBehaviour
{
  [SerializeField] private TextFader _textFader;
  private float FadeSpawnTime = 2.5f;
  [HideInInspector] public bool isPickUP = false;
    
  private void Update()
  {
    if (isPickUP)
    {
      _textFader.Fade();
      StartCoroutine(FadeOnOff());
      isPickUP = false;
    }
  }

  IEnumerator FadeOnOff()
  {
    yield return new WaitForSeconds(FadeSpawnTime);
    _textFader.Fade();
    Destroy(gameObject);
    yield return null;
  }
}