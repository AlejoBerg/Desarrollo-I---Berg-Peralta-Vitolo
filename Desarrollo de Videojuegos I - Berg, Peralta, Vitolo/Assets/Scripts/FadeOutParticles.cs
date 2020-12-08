using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutParticles : MonoBehaviour
{
    [SerializeField] private bool fadeWhenCollide = false; //Por si queres ejecutarlo con un collider
    [SerializeField] private ParticleSystem particlesToFade;
    [SerializeField] private float fadeOutTime;
    private Collider colliderRef = null;
    private ParticleSystem.MainModule psMain;
    private float initialMaxParticles = 0;
    private float counter = 0;

    private void Start()
    {
        psMain = particlesToFade.main;
        initialMaxParticles = psMain.maxParticles;
        
        if(fadeWhenCollide == true)
        {
            colliderRef = GetComponent<Collider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(fadeWhenCollide == true)
        {
            ExecuteFadeParticle();
        }
    }

    public void ExecuteFadeParticle()
    {
        StartCoroutine(FadeParticle());
    }

    private IEnumerator FadeParticle()
    {
        counter = 0;
        while (counter < fadeOutTime)
        {
            counter += Time.deltaTime;
            psMain.maxParticles = (int) Mathf.Lerp(initialMaxParticles, 0f, counter / fadeOutTime);
            yield return null;
        }
    }
}
