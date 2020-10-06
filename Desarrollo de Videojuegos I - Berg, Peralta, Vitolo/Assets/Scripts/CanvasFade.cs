using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFade : MonoBehaviour
{
    [SerializeField] private float duration = 1;
    [SerializeField] private int startAlpha = 0;
    [SerializeField] private int endAlpha = 1;
    private CanvasGroup canvasGroupRef;

    private void Start()
    {
        canvasGroupRef = GetComponent<CanvasGroup>();
    }

    public void DoFade()
    {
        StartCoroutine("FadeCanvasObject");
    }

    IEnumerator FadeCanvasObject() 
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroupRef.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / duration);

            yield return null;
        }
    }
}
