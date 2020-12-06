using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformsPuzzle3 : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool active = false;
    //private float time;
    [SerializeField] private float valueToPush;
    [SerializeField] private AudioSource activeButtonSFX;
    
    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Puzzle3.ActiveFalse)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }

    private void OnMouseDown()
    {
        if (!active)
        {
            Puzzle3.ItemsSelected.Add(this.gameObject);
            Puzzle3.AmountItemsSelected++;
            Puzzle3.MustCheck = true;
            PlatformAnimation();
            activeButtonSFX.Play();
            active = true;
        }
    }

    private void PlatformAnimation()
    {
       transform.Translate(-transform.forward / valueToPush);
      // transform.Translate(Vector3.Lerp(-transform.forward, -transform.forward / valueToPush, 0.1f));
    }
    
    public void ResetPositionOfPlattforms()
    {
        transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        active = false;
        Puzzle3.ActiveFalse = false;
    }
}