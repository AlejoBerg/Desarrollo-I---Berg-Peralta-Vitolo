using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformsPuzzle3 : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool active = false;
    [SerializeField] private float valueToPush;
    
    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!active)
        {
            Puzzle3New.ItemsSelected.Add(this.gameObject);
            Puzzle3New.AmountItemsSelected++;
            PlatformAnimation();
            active = true;
        }
    }

    private void PlatformAnimation()
    {
        transform.Translate(-transform.forward / valueToPush);
    }
    
    public void ResetPositionOfPlattforms()
    {
        transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        active = false;
    }
}