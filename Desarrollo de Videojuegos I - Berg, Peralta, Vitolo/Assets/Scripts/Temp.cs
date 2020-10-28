using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private void Update()
    {
       ChangeScene();
       QuitGame();
    }

    void ChangeScene()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            GameManager.Instance.ChangeCurrentState(State.Level1);
            GameManager.PlayerIsAlive = false;
        }
        
        if (Input.GetKey(KeyCode.F2))
        {
            GameManager.Instance.ChangeCurrentState(State.Level2);
            GameManager.PlayerIsAlive = false;
        }
        
        if (Input.GetKey(KeyCode.F3))
        {
            GameManager.Instance.ChangeCurrentState(State.Level3);
            GameManager.PlayerIsAlive = false;
        }
    }

    void QuitGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
