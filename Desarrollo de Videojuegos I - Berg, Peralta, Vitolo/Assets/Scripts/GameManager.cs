using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum State
{
    Menu,
    Level1,
    Level2,
    Level3,
}

public class GameManager
{
    private static GameManager instance;
    private State currenState;
    private static int score = 0;
    private static int parchmentsAmount = 0;
    private static Vector3 spawnPointLvl1 = new Vector3(-167.4f, -4.983f, -205.785f);
    private static Vector3 spawnPointLvl2 =  new Vector3(-1355f, -702,578f);
    private static Vector3 spawnPointLvl3 = new Vector3(0,1,0);
    
    public static int Score => score;
    public static int ParchmentsAmount => parchmentsAmount;
    public static Vector3 SpawnPointLvl1 => spawnPointLvl1;
    public static Vector3 SpawnPointLvl2 => spawnPointLvl2;
    public static Vector3 SpawnPointLvl3 => spawnPointLvl3;

    public static GameManager Instance 
    {
        get
        {
            if(instance == null) 
            {
                instance = new GameManager(); 
                Debug.Log("GameManager has been created");
            }
            return instance;
        }
    }
    
    public void Awake()
    {
        currenState = State.Level1;
    }

    public void Update()
    {
        switch (currenState)
            {
                case State.Menu:

                    break;

                case State.Level1:
                    Debug.Log("cambie a las coords del lvl 1");
                    SceneManager.LoadScene(0);
                    break;

                case State.Level2:
                    Debug.Log("cambie a las coords del lvl 2");
                    SceneManager.LoadScene(1);
                    break;

                case State.Level3:
                    Debug.Log("cambie a las coords del lvl 3");
                    SceneManager.LoadScene(2);
                    break;

               default:
                    break;
            }
    }


    public void ChangeCurrentScene(State newState)
    {
        currenState = newState;
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
