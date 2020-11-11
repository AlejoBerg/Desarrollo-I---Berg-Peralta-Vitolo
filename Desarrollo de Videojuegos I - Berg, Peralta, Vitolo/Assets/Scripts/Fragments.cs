using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fragments : MonoBehaviour
{
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField] private float typingSpeed = 0f;
    [SerializeField] private float TextExitTime = 3f;
    public bool activeMision = false;


    private void Update()
    {
       if (activeMision)
       {
           StartCoroutine(Type());
           textDisplay.GetComponent<TextFader>().Fade();
           activeMision = false;
       }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(TextExitTime);
        textDisplay.GetComponent<TextFader>().Fade();
        yield return new WaitForSeconds(TextExitTime);
        textDisplay.GetComponent<Text>().text = "";
    }
}