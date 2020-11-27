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
    [SerializeField] private GameObject imageToShow = null;
    [SerializeField] private GameObject colliderToHide = null;
    [SerializeField] private float imageToShowTimer = 0;
    private float initialVolume = 0;

    private void Start()
    {
        initialVolume = fadeOutMusic.volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && victoryCondition == GameManager.ParchmentsAmount)
        {
            fadeOutImage.DoFade();
            StartCoroutine("FadeMusicVolume");
            StartCoroutine("DelayBeforeLoadNextLvl");
        }
        else if (other.gameObject.CompareTag("Player") && victoryCondition != GameManager.ParchmentsAmount)
        {
            imageToShow.SetActive(true);
            if (colliderToHide != null) { colliderToHide.SetActive(false); }
            StartCoroutine(HideImage());
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

    IEnumerator HideImage()
    {
        yield return new WaitForSeconds(imageToShowTimer);
        imageToShow.SetActive(false);
    }

    IEnumerator DelayBeforeLoadNextLvl()
    {
        yield return new WaitForSeconds(delayBeforeLoadNextLevel);
        GameManager.LoadNextLevel = true;
    }
}