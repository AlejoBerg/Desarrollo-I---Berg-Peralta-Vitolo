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
            GameManagerOLD.ChangeCurrentScene(0);
            GameManagerOLD.ChangedLevel = true;
            Destroy(gameObject);
        }
        
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
            GameManagerOLD.ChangeCurrentScene(1);
            GameManagerOLD.ChangedLevel = true;
        }
        
        if (Input.GetKey(KeyCode.F3))
        {
            SceneManager.LoadScene(2);
            GameManagerOLD.ChangeCurrentScene(2);
            GameManagerOLD.ChangedLevel = true;
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
