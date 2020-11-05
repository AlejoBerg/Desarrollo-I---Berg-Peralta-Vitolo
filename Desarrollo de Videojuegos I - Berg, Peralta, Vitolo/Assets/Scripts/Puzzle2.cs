using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    public GameObject letterComplete;
    public GameObject textToCloseLetter;
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed = 0f;
    [SerializeField] private float TextExitTime = 1f;
    public bool activeMision = false;
    public Texture puzzleEnd;
    private int cont = 0;
    private int index;


    private void Update()
    {
        if (activeMision)
        {
            StartCoroutine(Type());
            textDisplay.GetComponent<TextFader>().Fade();
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

    void OccultPanel()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            letterComplete.SetActive(false);
            textToCloseLetter.SetActive(false);
        }
    }
}