using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private void Update()
    {
       RestartGame();
       QuitGame();
    }

    void RestartGame()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            GameManager.PlayerIsAlive = false;
            GameManager.Instance.ChangeCurrentState(State.Level1);
        }
        
        if (Input.GetKey(KeyCode.F2))
        {
            GameManager.PlayerIsAlive = false;
            GameManager.Instance.ChangeCurrentState(State.Level2);
        }
        
        if (Input.GetKey(KeyCode.F3))
        {
            GameManager.PlayerIsAlive = false;
            GameManager.Instance.ChangeCurrentState(State.Level3);
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
