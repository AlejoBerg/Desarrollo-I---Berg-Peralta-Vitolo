using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoadNextLevel = 0;
    [SerializeField] private int victoryCondition = 0;
    [SerializeField] private CanvasFade fadeOutImage = null;
    [SerializeField] private AudioSource fadeOutMusic = null;
    private float initialVolume = 0;

   private void Start()
    {
        initialVolume = fadeOutMusic.volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && victoryCondition == GameManager.ParchmentsAmount)
        {
            fadeOutImage.DoFade();
            StartCoroutine("FadeMusicVolume");
            StartCoroutine("DelayBeforeLoadNextLvl");
        }
    }

    IEnumerator FadeMusicVolume()
    {
        float counter = 0f;

        while (fadeOutMusic.volume > 0)
        {
            counter += Time.deltaTime;
            fadeOutMusic.volume = Mathf.Lerp(initialVolume, 0, counter / delayBeforeLoadNextLevel);
            yield return null;
        }
    }

    IEnumerator DelayBeforeLoadNextLvl()
    {
        yield return new WaitForSeconds(delayBeforeLoadNextLevel);
        GameManager.LoadNextLevel = true;
    }
}