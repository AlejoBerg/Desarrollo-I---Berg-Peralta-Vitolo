using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parchments : MonoBehaviour
{
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed = 0f;
   // [SerializeField] private AudioSource parchmentSFX = null;
    private int index;
    private bool finish = false;
    private float currentTextTime;
    [SerializeField] private float TextExitTime = 1f;
    [HideInInspector] public bool activeType = false;

    private void Update()
    {
        if (activeType)
        {
            transform.position = new Vector3(-1,-1,-1);
            StartCoroutine(Type());
            textDisplay.GetComponent<TextFader>().Fade();
            activeType = false;
            GameManager.AddParchment(1);
        }
        
        if (finish && currentTextTime >= TextExitTime)
        {
            textDisplay.GetComponent<TextFader>().Fade();
            Destroy(gameObject);
        }
        else
        {
            currentTextTime += Time.deltaTime;
        }
        if(textDisplay.GetComponent<CanvasGroup>().alpha == 0f){textDisplay.GetComponent<Text>().text = "";}
    }

    IEnumerator Type()
    {
        //parchmentSFX.Play();
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        currentTextTime = 0;
        finish = true;
    }
}
