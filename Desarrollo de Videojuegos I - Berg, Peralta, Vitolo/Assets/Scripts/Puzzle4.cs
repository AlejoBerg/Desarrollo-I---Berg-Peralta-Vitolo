﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4 : MonoBehaviour
{
    [SerializeField] private GameObject []bridge;
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed = 0f;
    [SerializeField] private float TextExitTime;
    [SerializeField] private GameObject activeComponent;
    [SerializeField] private GameObject colliderOut;
    [SerializeField] private AudioSource musicLVL;
    private int index;
    private int cont = 0;
    private bool stop = false;
    private static bool canRepair = false;
    
    public static bool CanRepair { get => canRepair; set => canRepair = value; }

    private void Update()
    {
        if (GameManager.ItemsToRepairTheBridge == 3 && !stop)
        {
            this.gameObject.GetComponent<PickeableObject>().isPickeable = true;
            if(canRepair){StartCoroutine(Repair());}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && cont !=1)
        {
            StartCoroutine(Type());
            textDisplay.GetComponent<TextFader>().Fade();
            GameManager.ActiveFade = true;
        }
    }

    IEnumerator Repair()
    {
        GameManager.ActiveFade = true;
        stop = true;
        for (int i = 0; i < bridge.Length; i++)
        {
            bridge[i].SetActive(true);
        }
        colliderOut.SetActive(false);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<ActiveFade>().enabled = false;
        yield return new WaitForSeconds(1f);
        activeComponent.GetComponent<ActiveFade>().enabled = true;
        musicLVL.Play();
        yield return null;
    }
    
    IEnumerator Type()
    {
        cont++;
        textDisplay.GetComponent<Text>().text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(TextExitTime);
        textDisplay.GetComponent<TextFader>().Fade();
    }
}