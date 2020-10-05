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
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
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
