using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LigthsOn : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    [SerializeField] private GameObject []Spot1ight;
    [SerializeField] private GameObject secondPlatform;
    [SerializeField] private GameObject eliminateWall;

    private void Update()
    {
        if (transform.position.y == 0.16f && secondPlatform.transform.position.y == 0.16f)
        {
            AllLigthsOn();
            eliminateWall.SetActive(false);
        }
    }

    private void OnCollisionStay (Collision other) 
    {
        if (other.gameObject.tag.Equals("Rocks"))
        {
            if(this.gameObject.transform.position.y != 0.16f){transform.Translate(new Vector3(0,-1f,0) *  platformSpeed);}
        }
    }

    void AllLigthsOn()
    {
        for (int i = 0; i < Spot1ight.Length; i++)
        {
            Spot1ight[i].SetActive(true);
        }
    }
}
