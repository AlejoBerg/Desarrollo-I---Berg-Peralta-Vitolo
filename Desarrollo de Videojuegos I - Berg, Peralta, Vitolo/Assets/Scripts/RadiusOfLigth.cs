using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusOfLigth : MonoBehaviour
{
    private Light light;
    private bool addOrSubtrac = false;
    [SerializeField] float limitOfRangeLight;

    private void Update()
    {
        if(addOrSubtrac){light.range = Mathf.Lerp(light.range, limitOfRangeLight, 0.005f);}
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
