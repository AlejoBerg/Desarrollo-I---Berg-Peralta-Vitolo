using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerAndCameraAtStart : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject cameraPrefab;
    private GameObject player;
    private GameObject camera;
    
    void Awake()
    {
        if (!GameManager.PlayerCreated)
        {
            player = Instantiate(prefab);
            camera = Instantiate(cameraPrefab);
            GameManager.Player.Add(player);
            GameManager.PlayerIsAlive = true;
            GameManager.Instance.Awake();
            DontDestroyOnLoad(this);
            GameManager.PlayerCreated = true;
        }
    }

    private void Update()
    {
        GameManager.Instance.Update();
    }
}
