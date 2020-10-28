using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerAtStart : MonoBehaviour
{
    public GameObject prefab;
    
    void Awake()
    {
        GameManager.Instance.Awake();
        Instantiate(prefab);
        GameManager.Player.Add(prefab);
        GameManager.PlayerIsAlive = true;
        //Destroy(this);
    }

    private void Update()
    {
        GameManager.Instance.Update();
    }
}
