using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static int score = 0;
    private static int parchmentsAmount = 0;
    
    public static int Score => score;
    public static int ParchmentsAmount => parchmentsAmount;

    public static void AddPoints(int newPoints)
    {
        score += newPoints;  
    }
    
    public static void AddParchment(int newParchment)
    {
        parchmentsAmount += newParchment;
    }
}
