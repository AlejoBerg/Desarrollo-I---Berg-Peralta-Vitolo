using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionables : MonoBehaviour
{
    [SerializeField] private TextFader _textFader;
    private float currentFadeTime;
    private float FadeSpawnTime = 2.5f;
    public bool activated = false;
    public bool isPickUP = false;
    
    private void FadeOff()
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

    private void Update()
    {
        if (isPickUP)
        { 
            _textFader.Fade();
            isPickUP = false;
            activated = true;
            GameManager.AddPoints(1);
        }
        
        if (activated)
        {
            FadeOff();
        }
    }
}
