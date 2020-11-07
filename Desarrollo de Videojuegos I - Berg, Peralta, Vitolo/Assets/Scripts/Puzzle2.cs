using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    private PickupObject pickupObjRef = null;
    [SerializeField] private FadeOutParticles fadeOutParticlesRef = null;
    [SerializeField] private FadeOutMusic[] fadeOutMusicRef = null;
    

    [SerializeField] private GameObject letterComplete;
    [SerializeField] private GameObject textToCloseLetter;
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    //[SerializeField] private PickeableObject[] notes;
    [SerializeField] private float typingSpeed = 0f;
    [SerializeField] private float TextExitTime = 1f;
    [SerializeField] private TextFader imageNoteComplete;
    [SerializeField] private TextFader pressTAB;
    public bool activeMision = false;
    public Texture puzzleEnd;
    private int cont = 0;
    private int index;
    private bool activeFadeAgain = true;
    private bool notAtStart = false;
    private float time = 20f;
    private float currentTime = 0;
    

    private void Awake()
    {
        pickupObjRef = GameManager.GameObjects[0].GetComponent<PickupObject>();
        pickupObjRef.OnPuzzle2Victory += OnPuzzle2VictoryHandler;

       /* for (int i = 0; i < notes.Length; i++)
        {
            notes[i].isPickeable = false;
        }*/
    }

    private void Update()
    {
        if (activeMision)
        {
            StartCoroutine(Type());
            //textDisplay.GetComponent<TextFader>().Fade();
            /*for (int i = 0; i < notes.Length; i++)
            {
                notes[i].isPickeable = true;
            }*/
            activeMision = false;
        }
        
        if (GameManager.FragmentsNotes == 10 && cont == 0)
        {
            this.gameObject.GetComponent<PickeableObject>().isPickeable = true;
            cont++;
        }
        OccultPanel();
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

    private void OnPuzzle2VictoryHandler()
    {
        fadeOutParticlesRef.ExecuteFadeParticle();
        for (int i = 0; i < fadeOutMusicRef.Length; i++)
        {
            fadeOutMusicRef[i].ExecuteFadeOutMusic();
        }
    }
}