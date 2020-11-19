using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTexts : MonoBehaviour
{
    [SerializeField] private TextFader letterToFade = null;
    [SerializeField] private TextFader imageMenssageToFade = null;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            letterToFade.Fade();
            imageMenssageToFade.Fade();
            this.gameObject.SetActive(false);
        }
    }
}