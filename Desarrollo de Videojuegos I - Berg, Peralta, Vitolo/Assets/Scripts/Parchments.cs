using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parchments : MonoBehaviour
{
    public GameObject textToShow;
    [SerializeField] private Text textDisplay;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed = 0f;
    private int index;
    public bool activeType = false;
    private bool finish = false;
    private float currentTextTime;
    private float TextExitTime = 1f;
   
    private void Update()
    {
        if (activeType)
        {
            transform.position = new Vector3(-1,-1,-1);
            StartCoroutine(Type());
            activeType = false;
        }
        
        if (finish && currentTextTime >= TextExitTime)
        {
            textDisplay.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            currentTextTime += Time.deltaTime;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        currentTextTime = 0;
        finish = true;
    }
}
