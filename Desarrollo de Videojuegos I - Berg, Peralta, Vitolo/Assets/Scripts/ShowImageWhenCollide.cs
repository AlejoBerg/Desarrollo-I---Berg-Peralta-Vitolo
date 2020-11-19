using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageWhenCollide : MonoBehaviour
{
    [SerializeField] private GameObject imageToShow = null;
    [SerializeField] private float imageToShowTimer = 0;
    private int cont = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && cont != 1)
        {
            imageToShow.SetActive(true);
            StartCoroutine(HideImage());
        }        
    }

    IEnumerator HideImage()
    {
        cont++;
        yield return new WaitForSeconds(imageToShowTimer);
        imageToShow.SetActive(false);
    }
}