using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5 : MonoBehaviour
{
    private bool doOnce = true;
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject platform3;
    
    void Update()
    {
        if (GameManager.ItemsAmount2 == 5 && doOnce)
        {
            // MOVER PLATAFORMA
            doOnce = false;
        }
    }
}
