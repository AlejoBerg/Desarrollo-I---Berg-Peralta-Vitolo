using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    private LineOfSight _visionItem;
    private GameObject _player;
    [SerializeField] private GameObject billboard;
    private void Start()
    {
        _visionItem = GetComponent<LineOfSight>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_visionItem.IsInSight(_player))
        {
            billboard.SetActive(true);
        }
        else
        {
            billboard.SetActive(false);
        }
    }
}