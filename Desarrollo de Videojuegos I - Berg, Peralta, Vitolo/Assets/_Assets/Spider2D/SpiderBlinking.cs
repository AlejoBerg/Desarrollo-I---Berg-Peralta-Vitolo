using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpiderBlinking : MonoBehaviour
{
    private VideoPlayer myVideoPlayer;
    private float randomStartTime = 0;

    private void Start()
    {
        myVideoPlayer = GetComponent<VideoPlayer>();
        randomStartTime = Random.Range(1, 7);
        StartCoroutine("DelayBeforeStartVideo");
    }

    IEnumerator DelayBeforeStartVideo()
    {
        yield return new WaitForSeconds(randomStartTime);
        myVideoPlayer.Play();
    }
}
