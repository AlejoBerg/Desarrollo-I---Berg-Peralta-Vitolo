using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3New : MonoBehaviour
{
  [SerializeField] private GameObject wallToEliminate;
  [SerializeField] private List<GameObject> conditionToFinish = new List<GameObject>();
  protected static List<GameObject> itemsSelected = new List<GameObject>();
  List<GameObject> playerResult = new List<GameObject>();
  protected static int amountItemsSelected = 0;
  
 
  public static List<GameObject> ItemsSelected { get => itemsSelected; set => itemsSelected = value; }
  public static int AmountItemsSelected { get => amountItemsSelected; set => amountItemsSelected = value; }

  private void Update()
  {
    if (amountItemsSelected == conditionToFinish.Count)
    {
      CheckPuzzle();
      amountItemsSelected = 0;
    }
  }

  void CheckPuzzle()
  {
    for (int i = 0; i < conditionToFinish.Count; i++)
    {
      if(conditionToFinish[i].GetInstanceID() == itemsSelected[i].GetInstanceID())
      {
        Debug.Log("condition" + conditionToFinish[i].GetInstanceID());
        Debug.Log("item" + itemsSelected[i].GetInstanceID());
        playerResult.Add(itemsSelected[i]);
      }
      else
      {
        Debug.Log("Deberia resetearse");
      }
    }

    if (playerResult.Count == conditionToFinish.Count)
    {
      GameManager.GameObjects[0].GetComponent<PlayerController>().ChangeJumpForce(7f);
      wallToEliminate.SetActive(false);
    }
  }
}