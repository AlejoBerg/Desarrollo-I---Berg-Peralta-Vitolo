using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    Menu,
    Level1,
    Level2,
    Level3,
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static int score = 0;
    private static int parchmentsAmount = 0;
    private State currenState;
    
    public static int Score => score;
    public static int ParchmentsAmount => parchmentsAmount;

    public static GameManager Instance 
    {
        get {
            if(instance == null) 
            {
                instance = new GameManager();
                Debug.Log("se creo");
            }
            return instance;
            }
    }
    
    public static void AddPoints(int newPoints)
    {
        score += newPoints;  
    }
    
    public static void AddParchment(int newParchment)
    {
        parchmentsAmount += newParchment;
    }
}