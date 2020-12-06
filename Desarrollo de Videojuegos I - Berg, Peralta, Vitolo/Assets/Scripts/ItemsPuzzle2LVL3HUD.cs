using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPuzzle2LVL3HUD : MonoBehaviour
{
    [SerializeField] private Text itemsPicked;
    
    void Update()
    {
        itemsPicked.text = ((GameManager.ItemsAmount2).ToString()+ " " + "/ 5");
    }
}