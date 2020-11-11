using System;
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
    [SerializeField] private GameObject brushGObject;
    [SerializeField] private GameObject parchmentToUnlock;
    public Texture puzzleEnd;
    private int cont = 0;
    private bool activeFadeAgain = true;
    private bool notAtStart = false;
    private float time = 20f;
    private float currentTime = 0;
    private float timeToMoveBrush;
    
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
            StartCoroutine(ItemToUnlock());
        }
        
        if(notAtStart){TimerToFade();}
    } 

    void TimerToFade()
    {
        if (currentTime >= time && activeFadeAgain)
        {
            letterComplete.GetComponent<TextFader>().Fade();
            textToCloseLetter.GetComponent<TextFader>().Fade();
            StartCoroutine(ItemToUnlock());
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
    
    IEnumerator ItemToUnlock()
    {
        parchmentToUnlock.SetActive(true);
        timeToMoveBrush += Time.deltaTime * 0.5f;
        brushGObject.transform.position = new Vector3(brushGObject.transform.position.x, (Mathf.Lerp(brushGObject.transform.position.y, brushGObject.transform.position.y - 6, timeToMoveBrush)), brushGObject.transform.position.z);
        yield return new WaitForSeconds(3f);
        activeFadeAgain = false;
        yield return null;
    }
}