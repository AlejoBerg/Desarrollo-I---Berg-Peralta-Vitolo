using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPuzzle2LVL3 : MonoBehaviour
{
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    [SerializeField] private GameObject []renderers;
   // [SerializeField] private MeshRenderer _renderer1;
    //[SerializeField] private MeshRenderer _renderer2;
    [SerializeField] private float typingSpeed = 0f;
    [SerializeField] private float TextExitTime;
    [HideInInspector]public bool activeMision = false;
    [HideInInspector]public bool isPickup = false;
    private int index;
    private bool doFade = true;
    
    private void Update()
    {
        if (activeMision)
        {
            //if (_renderer1 != null){_renderer1.enabled = false;}
            //if(_renderer2 != null){_renderer2.enabled = false;}

            if (renderers[0] != null)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            StartCoroutine(Type());
            textDisplay.GetComponent<TextFader>().Fade();
            activeMision = false;
        }

        if (GameManager.ItemsAmount2 == 5 && doFade)
        {
            GameManager.ActiveFade = true;
            doFade = false;
        }
    }

    IEnumerator Type()
    {
        textDisplay.GetComponent<Text>().text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(TextExitTime);
        textDisplay.GetComponent<TextFader>().Fade();
        Destroy(gameObject);
    }
}