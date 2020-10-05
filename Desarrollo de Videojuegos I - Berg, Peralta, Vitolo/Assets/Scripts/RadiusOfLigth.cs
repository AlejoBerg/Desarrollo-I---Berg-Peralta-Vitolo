using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusOfLigth : MonoBehaviour
{
    private Light light;
    private bool addOrSubtrac = false;
    [SerializeField] private float time;
    [SerializeField] float limitOfRangeLight;

    private void Update()
    {
        if(addOrSubtrac){light.range = Mathf.Lerp(light.range, limitOfRangeLight, time);}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            light = other.GetComponentInChildren<Light>();
            addOrSubtrac = true;
        }
    }
}
