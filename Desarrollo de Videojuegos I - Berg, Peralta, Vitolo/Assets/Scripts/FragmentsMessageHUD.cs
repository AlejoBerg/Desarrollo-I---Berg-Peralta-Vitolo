using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentsMessageHUD : MonoBehaviour
{
    [SerializeField] private Text Puntaje;
    
    void Update()
    {
        Puntaje.text = ("You need to search" + " " +(10 - GameManager.FragmentsNotes).ToString() + " " + "more fragments");
    }
}
