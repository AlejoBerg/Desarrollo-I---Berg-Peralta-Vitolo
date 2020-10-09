using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToThrow;
    [SerializeField] private GameObject colliderBlocking = null;
    [SerializeField] private AudioSource objectFallingSFX = null;

    private void Start()
    {
        for (int i = 0; i < objectsToThrow.Length; i++)
        {
            var rb = objectsToThrow[i].GetComponent<Rigidbody>();
            rb.isKinematic = true;
            if (colliderBlocking != null)
            {
                colliderBlocking.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            var colliderRef = GetComponent<Collider>();
            Destroy(colliderRef);
            objectFallingSFX.Play();
            for (int i = 0; i < objectsToThrow.Length; i++)
            {
                objectsToThrow[i].SetActive(true);
                var rb = objectsToThrow[i].GetComponent<Rigidbody>();
                rb.isKinematic = false;
            }

            if(colliderBlocking != null)
            {
                colliderBlocking.SetActive(true);
            }
        }
    }
}
