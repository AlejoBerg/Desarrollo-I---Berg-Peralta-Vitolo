using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPuzzle2LVL3 : MonoBehaviour
{
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField] private float typingSpeed = 0f;
    [SerializeField] private float TextExitTime;
    [HideInInspector]public bool activeMision = false;
    [HideInInspector]public bool isPickup = false;
    private bool doFade = true;
    
    private void Update()
    {
        if (activeMision)
        {
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