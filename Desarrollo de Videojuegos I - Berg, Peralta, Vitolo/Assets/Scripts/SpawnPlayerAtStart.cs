using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerAtStart : MonoBehaviour
{
    public PlayerController prefab;
    
    void Awake()
    {
        GameManager.Instance.Awake();
        Instantiate(prefab);
        GameManager.Player.Add(prefab);
        GameManager.Instance.Update();
        Destroy(this);
    }
}
