using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsOnWhenEnter : MonoBehaviour
{
    [SerializeField] private List<GameObject> lightsToTurnOn;
    [SerializeField] private PlayerController playerRef;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (var light in lightsToTurnOn)
            {
                light.SetActive(true);
            }
        }
    }
}
