using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField] private Sprite puzzleStart;
    [SerializeField] private Sprite puzzleEnd;
    private int cont = 0;


    private void Update()
    {
        if (GameManager.FragmentsNotes == 10 && cont == 0)
        {
            this.gameObject.GetComponent<PickeableObject>().isPickeable = true;
            cont++;
        }
    }
}
