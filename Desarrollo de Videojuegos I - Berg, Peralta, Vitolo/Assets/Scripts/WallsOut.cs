using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class WallsOut : MonoBehaviour
{
    private event Action OnCollisionWithRock;

    [SerializeField] private float platformSpeed = 0;
    [SerializeField] private WallsOut secondPlatform = null;
    [SerializeField] private GameObject eliminateWall = null;
    [SerializeField] private FadeOutParticles particlesWall = null;
    [SerializeField] private AudioSource platformSFX = null;
    private bool isActivated = false;
    private Vector3 initialPlatformPosition = Vector3.zero;
    private Vector3 endPlatformPosition = Vector3.zero;
    private float time = 0f;
    private bool wallWasFaded = false;

    private void Start()
    {
        OnCollisionWithRock += OnCollisionWithRockHandler;
        initialPlatformPosition = transform.position;
        endPlatformPosition = initialPlatformPosition + new Vector3(0,-0.1f,0);
    }
    
    private void Update()
    {
        if (isActivated && secondPlatform.isActivated == true)
        {
            if (wallWasFaded == false)
            {
                wallWasFaded = true;
                particlesWall.ExecuteFadeParticle();
            }
            eliminateWall.SetActive(false);
        }
    }

    private void OnCollisionStay (Collision other) 
    {
        if (other.gameObject.tag.Equals("Rocks"))
        {
            print("reproduzco el sonido");
            platformSFX.Play();
            isActivated = true;
            OnCollisionWithRock.Invoke();
        }
    }
    
    private void OnCollisionWithRockHandler()
    {
        time += Time.deltaTime * 0.5f;
        transform.position = new Vector3(initialPlatformPosition.x, (Mathf.Lerp(initialPlatformPosition.y, endPlatformPosition.y, time)), initialPlatformPosition.z);
    }
}