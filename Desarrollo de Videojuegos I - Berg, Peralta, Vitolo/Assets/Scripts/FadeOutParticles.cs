using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutParticles : MonoBehaviour
{
    [SerializeField] private float fadeOutTime;
    [SerializeField] private float particlesAmount;
    private ParticleSystem myParticles;
    private float counter = 0;



    private void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        StartCoroutine("FadeParticle");
    }

    private IEnumerator FadeParticle()
    {
        counter = 0;
        var emission = myParticles.emission;

        while (counter < fadeOutTime)
        {
            counter += Time.deltaTime;
            emission.rateOverTime = particlesAmount;
            particlesAmount -= Time.deltaTime;

            yield return null;
        }
    }
}
