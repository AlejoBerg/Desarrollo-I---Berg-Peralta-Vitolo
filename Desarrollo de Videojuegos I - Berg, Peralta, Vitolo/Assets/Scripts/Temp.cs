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
            SceneManager.LoadScene(0);
            GameManager.Instance.Update();
        }
        
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
            GameManager.Instance.ChangeCurrentState(State.Level2);
            GameManager.Instance.Update();
        }
        
        if (Input.GetKey(KeyCode.F3))
        {
            SceneManager.LoadScene(2);
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
