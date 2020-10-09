using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate;
    [SerializeField] private string tagForTrigger = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagForTrigger)
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
            }
        }
    }
}
