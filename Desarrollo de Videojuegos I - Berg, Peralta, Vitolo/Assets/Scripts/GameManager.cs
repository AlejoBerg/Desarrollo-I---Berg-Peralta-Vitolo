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
    private static int fragmentsNotes = 0;
    private static int itemsToRepairTheBridge = 0;
    private static bool activeFade = false;
    private static bool canDestroyDirectly = false;
    //private Vector3 spawnPointLvl1 = new Vector3(-167.4f, -4.983f, -205.785f);
    private  Vector3 spawnPointLvl1 = new Vector3(-26f, 1f, -7f); //Seba Scene Coords
    private Vector3 spawnPointLvl2 = new Vector3(-1363f, -703f, 574);
    private Vector3 spawnPointLvl3 = new Vector3(111f, 50f, 8f);
    private static List<GameObject> gameObjects = new List<GameObject>();

    public static int Score => score;
    public static int ParchmentsAmount => parchmentsAmount;
    public static int FragmentsNotes => fragmentsNotes;
    public static int ItemsToRepairTheBridge => itemsToRepairTheBridge;
    public static bool PlayerIsAlive { get => playerIsAlive; set => playerIsAlive = value; }
    public static bool CanDestroyDirectly { get => canDestroyDirectly; set => canDestroyDirectly = value; }
    public static bool ActiveFade { get => activeFade; set => activeFade = value; }
    public static bool PlayerCreated { get => playerCreated; set => playerCreated = value; }
    public static bool LoadNextLevel { get => loadNextLevel; set => loadNextLevel = value; }
    public static List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public void Awake()
    {
        currenState = State.Level1;
        gameObjects[0].transform.position = spawnPointLvl1;
        gameObjects[0].transform.rotation = Quaternion.Euler(0, 0f, 0);
        gameObjects[1].GetComponent<ThirdCameraController>().ChangeCameraPos(18f, -359f);
    }

    public void Update()
    {
        if (parchmentsAmount == 5 && currenState == State.Level1 && loadNextLevel)
        {
            instance.ChangeCurrentState(State.Level2);
            playerIsAlive = false;
            loadNextLevel = false;
        }
        if (parchmentsAmount == 7 && currenState == State.Level2 && loadNextLevel)
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
                    gameObjects[0].transform.position = spawnPointLvl1;
                    gameObjects[0].transform.rotation = Quaternion.Euler(0, 0f, 0);
                    gameObjects[0].GetComponent<PlayerController>().ChangeWalkPlayerSpeed(1.5f);
                    gameObjects[0].GetComponent<PlayerController>().ChangeConditionToRun(false);
                    gameObjects[0].GetComponent<PlayerController>().ChangeConditionToJump(false);
                    gameObjects[1].GetComponent<ThirdCameraController>().ChangeDistanceToPlayer(3f);
                    gameObjects[1].GetComponent<ThirdCameraController>().ChangeCameraPos(18f, -359f);
                    parchmentsAmount = 0;
                    playerIsAlive = true;
                }
                break;

            case State.Level2:

                if (!playerIsAlive)
                {
                    SceneManager.LoadScene(2);
                    gameObjects[0].transform.position = spawnPointLvl2;
                    gameObjects[0].transform.eulerAngles = new Vector3(0, 90, 0);
                    gameObjects[0].GetComponent<PlayerController>().ChangeWalkPlayerSpeed(2f);
                    gameObjects[0].GetComponent<PlayerController>().ChangeConditionToRun(true);
                    gameObjects[0].GetComponent<PlayerController>().ChangeConditionToJump(true);
                    gameObjects[1].GetComponent<ThirdCameraController>().ChangeDistanceToPlayer(4.4f);
                    gameObjects[1].GetComponent<ThirdCameraController>().ChangeCameraPos(20f, -270f);
                    parchmentsAmount = 0;
                    playerIsAlive = true;
                }
                break;

            case State.Level3:

                if (!playerIsAlive)
                {
                    SceneManager.LoadScene(3);
                    gameObjects[0].transform.position = spawnPointLvl3;
                    gameObjects[0].transform.eulerAngles = new Vector3(0, 0, 0);
                    gameObjects[0].GetComponent<PlayerController>().ChangeWalkPlayerSpeed(2f);
                    gameObjects[0].GetComponent<PlayerController>().ChangeJumpForce(4f);
                    gameObjects[0].GetComponent<PlayerController>().ChangeConditionToRun(true);
                    gameObjects[0].GetComponent<PlayerController>().ChangeConditionToJump(true);
                    gameObjects[1].GetComponent<ThirdCameraController>().ChangeDistanceToPlayer(4.4f);
                    gameObjects[1].GetComponent<ThirdCameraController>().ChangeCameraPos(20f, -270f);
                    parchmentsAmount = 0;
                    playerIsAlive = true;
                }
                break;

            default:
                break;
        }

        if (parchmentsAmount == 2 && currenState == State.Level1)
        {
            gameObjects[0].GetComponent<PlayerController>().ChangeConditionToJump(true);
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

    public static void AddFragment(int newFragment)
    {
        fragmentsNotes += newFragment;
    }
    
    public static void AddItems(int newItem)
    {
        itemsToRepairTheBridge += newItem;
    }
}