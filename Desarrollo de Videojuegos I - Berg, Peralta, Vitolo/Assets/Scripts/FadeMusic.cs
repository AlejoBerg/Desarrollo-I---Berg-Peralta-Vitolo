using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [SerializeField] private bool fadeWhenCollide = false; //Por si queres ejecutarlo con un collider
    [SerializeField] private float initialVolume = 0; 
    [SerializeField] private float endVolume = 1; 
    [SerializeField] private AudioSource musicToFadeOut = null;
    [SerializeField] private float fadeTime;
    private Collider colliderRef = null;

    private void Awake()
    {
        if(initialVolume == 0)
        {
            musicToFadeOut.Stop();
        }

        if (fadeWhenCollide == true)
        {
            colliderRef = GetComponent<Collider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(fadeWhenCollide == true && other.gameObject.CompareTag("Player")) 
        {
            StartCoroutine("FadeMusicVolume");
        }
    }

    public void ExecuteFadeOutMusic()
    {
        StartCoroutine("FadeMusicVolume");
    }

    IEnumerator FadeMusicVolume()
    {
        if (initialVolume == 0)
        {
            musicToFadeOut.Play();
        }

        float counter = 0f;

        while (musicToFadeOut.volume > 0)
        {
            print("fading music");
            counter += Time.deltaTime;
            musicToFadeOut.volume = Mathf.Lerp(initialVolume, endVolume, counter / fadeTime);
            yield return null;
        }
        yield break;
    }
}
