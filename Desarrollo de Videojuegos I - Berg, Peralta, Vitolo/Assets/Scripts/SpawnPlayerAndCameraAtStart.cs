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
            GameManager.GameObjects.Add(player);
            GameManager.GameObjects.Add(camera);
            GameManager.Instance.Awake();
            GameManager.PlayerIsAlive = true;
            GameManager.PlayerCreated = true;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        GameManager.Instance.Update();
    }
}
