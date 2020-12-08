using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeValueOfParticles : MonoBehaviour
{
    private void Awake()
    {
        ParticleSystem particle = this.gameObject.GetComponent<ParticleSystem>();
        var main = particle.main;
        main.maxParticles = 0;
    }

    public void SetMinMaxParticles(int value)
    {
        ParticleSystem particle = this.gameObject.GetComponent<ParticleSystem>();
        var main = particle.main;
        main.maxParticles = value;
    }
}