using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour
{
    [SerializeField] private Text Puntaje;
    
    void Update()
    {
        Puntaje.text = GameManagerOLD.Score.ToString();
    }
}
