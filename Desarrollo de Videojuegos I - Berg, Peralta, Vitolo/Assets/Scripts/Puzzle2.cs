using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField] private FadeOutParticles fadeOutRainParticlesRef = null;
    [SerializeField] private FadeOutParticles fadeOutWallParticlesRef = null;
    [SerializeField] private FadeMusic[] fadeOutMusicRef = null;
    [SerializeField] private GameObject letterComplete;
    [SerializeField] private GameObject textToCloseLetter;
    [SerializeField] private GameObject wallOut = null;
    [SerializeField] private GameObject colliderOut = null;
    [SerializeField] private AudioSource finishMissionSFX;
    public Texture puzzleEnd;
    private int cont = 0;
    private bool activeFadeAgain = true;
    private bool notAtStart = false;
    private float timeToMoveBrush;
    public bool finished = false;
    public bool canShowAgain = false;
    
    private void Update()
    {
        if (GameManager.FragmentsNotes == 10 && cont == 0)
        {
            StartCoroutine(PlaySoundWithDelay());
            this.gameObject.GetComponent<PickeableObject>().isPickeable = true;
            cont++;
        }
        OccultPanel();
    }
    
    public void FadeText()
    {
        letterComplete.GetComponent<TextFader>().Fade();
        textToCloseLetter.GetComponent<TextFader>().Fade();
        notAtStart = true;
        wallOut.SetActive(false);
        cont++;
    }
    
    public void FadeText2()
    {
        letterComplete.GetComponent<TextFader>().Fade();
        textToCloseLetter.GetComponent<TextFader>().Fade();
        activeFadeAgain = true;
        cont++;
    }
    
    void OccultPanel()
    {
        if (Input.GetKey(KeyCode.Tab) && activeFadeAgain && notAtStart)
        {
            if(cont <= 2){OnPuzzle2Victory();}
            letterComplete.GetComponent<TextFader>().Fade();
            textToCloseLetter.GetComponent<TextFader>().Fade();
            activeFadeAgain = false;
            colliderOut.SetActive(false);
            this.gameObject.GetComponent<PickeableObject>().isPickeable = true;
            canShowAgain = true;
        }
    }

    private void OnPuzzle2Victory()
    {
        fadeOutWallParticlesRef.ExecuteFadeParticle();
        fadeOutRainParticlesRef.ExecuteFadeParticle();
        for (int i = 0; i < fadeOutMusicRef.Length; i++)
        {
            fadeOutMusicRef[i].ExecuteFadeOutMusic();
        }
    }

    IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(0.4f);
        finishMissionSFX.Play();
    }
}