using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsToRepairBridgeHUD : MonoBehaviour
{
    [SerializeField] private Text itemsPicked;
    
    void Update()
    {
        itemsPicked.text = ((GameManager.ItemsToRepairTheBridge).ToString()+ " " + "/ 3");
    }
}
