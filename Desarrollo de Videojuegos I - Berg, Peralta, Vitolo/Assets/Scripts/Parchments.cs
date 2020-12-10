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
    [SerializeField] private float TextExitTime = 1f;
    [HideInInspector] public bool activeType = false;
    [SerializeField] private MeshRenderer _renderer1;
    [SerializeField] private MeshRenderer _renderer2;
    [SerializeField] private MeshRenderer _renderer3;
    [SerializeField] private FadeOutParticles fadePetals;
    [SerializeField] private FadeMusic soundArea;
    private int index;

    private void Update()
    {
        if (activeType)
        {
            _renderer1.enabled = false;
            _renderer2.enabled = false;
            _renderer3.enabled = false;
            if(fadePetals != null){fadePetals.ExecuteFadeParticle();}
            soundArea.ExecuteFadeOutMusic();
            StartCoroutine(Type());
            textDisplay.GetComponent<TextFader>().Fade();
            activeType = false;
        }
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
        Destroy(gameObject);
    }
}