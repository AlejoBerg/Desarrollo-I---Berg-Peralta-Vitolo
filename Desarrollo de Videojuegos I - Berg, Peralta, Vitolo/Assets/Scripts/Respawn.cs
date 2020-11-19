using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private TextFader fadeOutImage;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeToFade;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            fadeOutImage.Fade();
            StartCoroutine(DelayBeforeRespawn());
        }
    }

    IEnumerator DelayBeforeRespawn()
    {
        yield return new WaitForSeconds(timeToFade);
        GameManager.GameObjects[0].transform.position = spawnPoint.position;
        fadeOutImage.Fade();
    }
}