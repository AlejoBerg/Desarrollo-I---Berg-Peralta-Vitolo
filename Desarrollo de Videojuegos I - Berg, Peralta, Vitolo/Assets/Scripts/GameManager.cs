using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static int score = 0;
    private static int parchmentsAmount = 0;
    private static Vector3 spawnPointLvl1 = new Vector3(-167.4f, -4.983f, -205.785f);
    private static Vector3 spawnPointLvl2 = new Vector3(-1366.58f, -703.0021f,576.4408f);
    private static Vector3 spawnPointLvl3 = new Vector3(0,1,0);
    private static int currentScene = 0;
    private static bool changedLevel = false;
    
    public static int Score => score;
    public static int ParchmentsAmount => parchmentsAmount;
    public static Vector3 SpawnPointLvl1 => spawnPointLvl1;
    public static Vector3 SpawnPointLvl2 => spawnPointLvl2;
    public static Vector3 SpawnPointLvl3 => spawnPointLvl3;
    public static int CurrentScene => currentScene;
    public static bool ChangedLevel{ get => changedLevel; set => changedLevel = value; }

    public static void ChangeCurrentScene(int newScene)
    {
        currentScene = newScene;
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