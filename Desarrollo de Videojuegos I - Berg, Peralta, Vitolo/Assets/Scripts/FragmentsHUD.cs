using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentsHUD : MonoBehaviour
{
    [SerializeField] private Text FragmentsPicked;
    
    void Update()
    {
        FragmentsPicked.text = GameManager.FragmentsNotes.ToString();
    }
}
