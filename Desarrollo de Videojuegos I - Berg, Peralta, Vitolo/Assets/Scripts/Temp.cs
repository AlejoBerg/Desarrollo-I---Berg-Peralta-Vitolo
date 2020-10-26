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
            GameManager.ChangeCurrentScene(0);
            GameManager.ChangedLevel = true;
            Destroy(gameObject);
        }
        
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
            GameManager.ChangeCurrentScene(1);
            GameManager.ChangedLevel = true;
        }
        
        if (Input.GetKey(KeyCode.F3))
        {
            SceneManager.LoadScene(2);
            GameManager.ChangeCurrentScene(2);
            GameManager.ChangedLevel = true;
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
