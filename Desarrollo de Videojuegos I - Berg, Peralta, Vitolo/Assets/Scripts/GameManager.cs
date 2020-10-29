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
    private static bool playerIsAlive = false;
    private static bool loadNextLevel = false;
    private static bool playerCreated = false;
    private static int parchmentsAmount = 0;
    private  Vector3 spawnPointLvl1 = new Vector3(-167.4f, -4.983f, -205.785f);
    private  Vector3 spawnPointLvl2 =  new Vector3(-1366f, -702f,568f);
    private  Vector3 spawnPointLvl3 = new Vector3(0,1,0);
    private static List<GameObject> player = new List<GameObject>();

    public static int Score => score;
    public static int ParchmentsAmount => parchmentsAmount;
    public static bool PlayerIsAlive { get => playerIsAlive; set => playerIsAlive = value; }
    public static bool PlayerCreated { get => playerCreated; set => playerCreated = value; }
    public static bool LoadNextLevel { get => loadNextLevel; set => loadNextLevel = value; }
    public static List<GameObject> Player { get => player; set => player = value; }

    public static GameManager Instance 
    {
        get
        {
            if(instance == null) 
            {
                instance = new GameManager(); 
            }
            return instance;
        }
    }
    
    public void Awake()
    {
        currenState = State.Level1;
        player[0].transform.position = spawnPointLvl1;
    }

    public void Update()
    {
        if (parchmentsAmount == 5 && currenState == State.Level1 && loadNextLevel)
        {
            instance.ChangeCurrentState(State.Level2);
            playerIsAlive = false;
            loadNextLevel = false;
        }
        if (parchmentsAmount == 11 && currenState == State.Level2 && loadNextLevel)
        {
            instance.ChangeCurrentState(State.Level3);
            playerIsAlive = false;
            loadNextLevel = false;
        }
        
        switch (currenState)
            {
                case State.Menu:

                    break;

                case State.Level1:

                    if (!playerIsAlive)
                    {
                        SceneManager.LoadScene(0);
                        player[0].transform.position = spawnPointLvl1;
                        playerIsAlive = true;
                    } 
                    break;

                case State.Level2:
                    
                    if (!playerIsAlive)
                    {
                        SceneManager.LoadScene(1);
                        player[0].transform.position = spawnPointLvl2;
                        playerIsAlive = true;
                    } 
                    break;

                case State.Level3:
                    
                    if (!playerIsAlive)
                    {
                        SceneManager.LoadScene(2);
                        player[0].transform.position = spawnPointLvl3;
                        playerIsAlive = true;
                    }
                    break;

               default:
                    break;
            }
    }

    public void ChangeCurrentState(State newState)
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