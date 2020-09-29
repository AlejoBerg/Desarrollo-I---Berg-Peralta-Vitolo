using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutParticles : MonoBehaviour
{
    [SerializeField] private float fadeOutTime;
    private ParticleSystem myParticles;
    private ParticleSystem.MainModule psMain;
    private float initialMaxParticles = 0;
    private float counter = 0;

    private void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        psMain = myParticles.main;
        initialMaxParticles = psMain.maxParticles;
    }

    public void ExecuteFadeParticle()
    {
        StartCoroutine("FadeParticle");
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
