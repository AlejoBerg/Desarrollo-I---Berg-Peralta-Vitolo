using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerAtStart : MonoBehaviour
{
    public GameObject prefab;
    private GameObject player;
    void Awake()
    {
            player = Instantiate(prefab);
            GameManager.Player.Add(player);
            GameManager.PlayerIsAlive = true;
            GameManager.Instance.Awake();
            DontDestroyOnLoad(this);
    }

    private void Update()
    {
        GameManager.Instance.Update();
    }
}
