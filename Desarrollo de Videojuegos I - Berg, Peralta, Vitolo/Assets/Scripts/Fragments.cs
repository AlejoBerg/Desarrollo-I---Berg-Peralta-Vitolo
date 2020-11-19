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
    [SerializeField] private float TextExitTime;
    public bool activeMision = false;
    public bool isPickup = false;


    private void Update()
    {
       if (activeMision)
       {
           StartCoroutine(Type());
           textDisplay.GetComponent<TextFader>().Fade();
           activeMision = false;
       }
       
       if (GameManager.CanDestroyDirectly && isPickup) {StartCoroutine(FragmentsDestroy());}
    }

    IEnumerator Type()
    {
        textDisplay.GetComponent<Text>().text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(TextExitTime);
        textDisplay.GetComponent<TextFader>().Fade();
        GameManager.CanDestroyDirectly = true;
        Destroy(gameObject);
    }
    
    
    IEnumerator FragmentsDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}