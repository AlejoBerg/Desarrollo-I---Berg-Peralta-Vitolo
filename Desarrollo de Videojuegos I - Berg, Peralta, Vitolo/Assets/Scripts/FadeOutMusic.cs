using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicToFadeOut = null;
    [SerializeField] private float fadeOutTime;
    private float initialVolume = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            initialVolume = musicToFadeOut.volume;
            StartCoroutine("FadeMusicVolume");
        }
    }

    public void ExecuteFadeOutMusic()
    {
        StartCoroutine("FadeMusicVolume");
    }

    IEnumerator FadeMusicVolume()
    {
        float counter = 0f;

        while (musicToFadeOut.volume > 0)
        {
            counter += Time.deltaTime;
            musicToFadeOut.volume = Mathf.Lerp(initialVolume, 0, counter / fadeOutTime);
            yield return null;
        }
    }
}
