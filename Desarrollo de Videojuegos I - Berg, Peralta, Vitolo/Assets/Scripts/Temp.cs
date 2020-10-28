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
            GameManager.Instance.Update();
        }
        
        if (Input.GetKey(KeyCode.F2))
        {
            GameManager.Instance.ChangeCurrentState(State.Level2);
            var pos = GameObject.Find("SpawnPoint");
            transform.position = pos.transform.position;
            GameManager.Instance.Update();
        }
        
        if (Input.GetKey(KeyCode.F3))
        {
            GameManager.Instance.ChangeCurrentState(State.Level3);
            GameManager.Instance.Update();
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
