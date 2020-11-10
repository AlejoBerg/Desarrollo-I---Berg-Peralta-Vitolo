﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField] private FadeOutParticles fadeOutParticlesRef = null;
    [SerializeField] private FadeMusic[] fadeOutMusicRef = null;
    
    [SerializeField] private GameObject letterComplete;
    [SerializeField] private GameObject textToCloseLetter;
    public Texture puzzleEnd;
    private int cont = 0;
    private bool activeFadeAgain = true;
    private bool notAtStart = false;
    private float time = 20f;
    private float currentTime = 0;
    

    private void Update()
    {
        if (GameManager.FragmentsNotes == 10 && cont == 0)
        {
            this.gameObject.GetComponent<PickeableObject>().isPickeable = true;
            cont++;
        }
        OccultPanel();
    }
    
    public void FadeText()
    {
        letterComplete.GetComponent<TextFader>().Fade();
        textToCloseLetter.GetComponent<TextFader>().Fade();
        currentTime = 0;
        notAtStart = true;
    }
    
    void OccultPanel()
    {
        if (Input.GetKey(KeyCode.Tab) && activeFadeAgain && notAtStart)
        {
            OnPuzzle2Victory();
            letterComplete.GetComponent<TextFader>().Fade();
            textToCloseLetter.GetComponent<TextFader>().Fade();
            activeFadeAgain = false;
        }
        
        if(notAtStart){TimerToFade();}
    } 

    void TimerToFade()
    {
        if (currentTime >= time && activeFadeAgain)
        {
            letterComplete.GetComponent<TextFader>().Fade();
            textToCloseLetter.GetComponent<TextFader>().Fade();
            activeFadeAgain = false;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    private void OnPuzzle2Victory()
    {
        print("se ejecuta fade");
        fadeOutParticlesRef.ExecuteFadeParticle();
        for (int i = 0; i < fadeOutMusicRef.Length; i++)
        {
            fadeOutMusicRef[i].ExecuteFadeOutMusic();
        }
    }
}