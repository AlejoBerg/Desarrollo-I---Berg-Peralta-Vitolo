using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LigthsOn : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    [SerializeField] private GameObject []Spot1ight;
    [SerializeField] private LigthsOn secondPlatform;
    [SerializeField] private GameObject eliminateWall;
    private float currentLightsOnTime;
    private float LightsOnSpawnTime = 2f;
    private Vector3 initialPlatformPosition = Vector3.zero;
    private Vector3 endPlatformPosition = Vector3.zero;
    private float speed = 1f;
    private float step;
    private float time = 0f;
    public bool isActivated = false;

    private void Start()
    {
        initialPlatformPosition = transform.position;
        endPlatformPosition = initialPlatformPosition + new Vector3(0,-0.1f,0);
    }
    
    private void Update()
    {
        if (isActivated && secondPlatform.isActivated == true)
        {
            AllLigthsOn();
            eliminateWall.SetActive(false);
        }
    }

    private void OnCollisionStay (Collision other) 
    {
        if (other.gameObject.tag.Equals("Rocks"))
        {
            PlatformAnimation();
            isActivated = true;
        }
    }
    
    void AllLigthsOn()
    {
        for (int i = 0; i < Spot1ight.Length; i++)
        {
            if (currentLightsOnTime >= LightsOnSpawnTime)
            {
                Spot1ight[i].SetActive(true);
                currentLightsOnTime = 0;
            }
            else
            {
                currentLightsOnTime += Time.deltaTime;
            }
        }
    }
    
    private void PlatformAnimation()
    {
        time += Time.deltaTime * 0.5f;
        transform.position = new Vector3(initialPlatformPosition.x, (Mathf.Lerp(initialPlatformPosition.y, endPlatformPosition.y , time)), initialPlatformPosition.z);
    }
}
