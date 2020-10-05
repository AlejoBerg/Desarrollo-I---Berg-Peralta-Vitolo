using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToThrow;
    [SerializeField] private AudioSource objectFallingSFX;

    private void Start()
    {
        for (int i = 0; i < objectsToThrow.Length; i++)
        {
            var rb = objectsToThrow[i].GetComponent<Rigidbody>();
            rb.isKinematic = true;
            //objectsToThrow[i].SetActive(false);
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
        }
    }
}
