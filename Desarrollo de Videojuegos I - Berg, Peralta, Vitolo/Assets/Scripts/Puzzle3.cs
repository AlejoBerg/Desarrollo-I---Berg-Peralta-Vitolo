using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle3 : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] private Puzzle3[] Plattforms;
    [SerializeField] private GameObject eliminateWall;
    private bool active = false;
    private static bool condition = false;
    
    public static bool Condition { get => condition; set => condition = value; }
    
    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Plattforms[1].active || Plattforms[2].active || Plattforms[4].active || Plattforms[5].active || Plattforms[6].active || Plattforms[7].active)
        {
            transform.position = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z);
            active = false;
            Plattforms[0].active = false;
            Plattforms[3].active = false;
            Plattforms[8].active = false;
            Plattforms[0].transform.position = new Vector3(Plattforms[0].initialPosition.x,Plattforms[0].initialPosition.y,Plattforms[0].initialPosition.z);
            Plattforms[3].transform.position = new Vector3(Plattforms[3].initialPosition.x,Plattforms[3].initialPosition.y,Plattforms[3].initialPosition.z);
            Plattforms[8].transform.position = new Vector3(Plattforms[8].initialPosition.x,Plattforms[8].initialPosition.y,Plattforms[8].initialPosition.z);
        }
        
        if (Plattforms[0].active && Plattforms[3].active && Plattforms[8].active)
        {
            GameManager.GameObjects[0].GetComponent<PlayerController>().ChangeJumpForce(7f);
            eliminateWall.SetActive(false);
            StartCoroutine(RestartPlatformsPos());
        }

        if (condition)
        {
            StartCoroutine(RestartPuzzle());
            condition = false;
        }
    }

    private void OnMouseDown()
    {
        PlatformAnimation();
        active = true;
    }

    private void PlatformAnimation()
    {
       transform.position = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z + 0.10f);
    }

    IEnumerator RestartPlatformsPos()
    {
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z);
        yield return new WaitForSeconds(1);
        active = false;
    }
    
    IEnumerator RestartPuzzle()
    {
        GameManager.GameObjects[0].GetComponent<PlayerController>().ChangeJumpForce(4f);
        yield return new WaitForSeconds(2f);
        eliminateWall.SetActive(true);
        yield return null;
    }
}