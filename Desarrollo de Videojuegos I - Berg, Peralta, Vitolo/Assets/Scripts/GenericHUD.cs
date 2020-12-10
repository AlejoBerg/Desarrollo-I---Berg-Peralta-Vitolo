using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericHUD : MonoBehaviour
{
    [SerializeField] private Text textBoxToShowValues;
    [SerializeField] private bool scorePuzzle1LVL2;
    [SerializeField] private bool scorePuzzle1LVL3;
    [SerializeField] private bool scorePuzzle2LVL3;
    [SerializeField] private float amountOfItems;
    void Update()
    {   
        if(scorePuzzle1LVL2){textBoxToShowValues.text = ((GameManager.FragmentsNotes).ToString() + " " + "/" + amountOfItems);}
        if(scorePuzzle1LVL3){textBoxToShowValues.text = ((GameManager.ItemsToRepairTheBridge).ToString() + " " + "/" + amountOfItems);}
        if(scorePuzzle2LVL3){textBoxToShowValues.text = ((GameManager.ItemsAmount2).ToString() + " " + "/" + amountOfItems);}
    }
}
