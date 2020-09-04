using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LigthsOn : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 0;
    [SerializeField] private GameObject []Spot1ight ;
    [SerializeField] private LigthsOn secondPlatform = null;
    [SerializeField] private GameObject eliminateWall = null;
    [SerializeField] private bool isActivated = false;
    private float currentLightsOnTime;
    private float LightsOnSpawnTime = 2f;
    private Vector3 initialPlatformPosition = Vector3.zero;
    private Vector3 endPlatformPosition = Vector3.zero;
    private float time = 0f;

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
