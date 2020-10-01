using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    public static int Score => score;
    
    public static void AddPoints(int newPoints)
    {
        score += newPoints;  
    }
}
