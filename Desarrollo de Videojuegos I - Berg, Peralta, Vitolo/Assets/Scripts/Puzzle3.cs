using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3 : MonoBehaviour
{
  [SerializeField] private GameObject wallToEliminate;
  [SerializeField] private List<GameObject> conditionToFinish = new List<GameObject>();
  [SerializeField] private AudioSource finishMissionSFX;
  [SerializeField] private AudioSource failMissionSFX;
  [SerializeField] private GameObject textDisplay;
  [SerializeField] private string[] sentences;
  [SerializeField] private float typingSpeed = 0f;
  [SerializeField] private float TextExitTime;
  //[SerializeField] private GameObject prefabTraill;
  //[SerializeField] private Vector3 traillPosition;
  protected static List<GameObject> playerResult = new List<GameObject>();
  protected static List<GameObject> itemsSelected = new List<GameObject>();
  protected static int amountItemsSelected = 0;
  protected static bool activeFalse;
  protected static bool mustCheck =false;
  private int index;
  private int cont = 0;
  private int j = 0;
  //private GameObject instanciatedTraill;
  
  public static List<GameObject> ItemsSelected { get => itemsSelected; set => itemsSelected = value; }
  public static List<GameObject> PlayerResult { get => playerResult; set => playerResult = value; }
  public static int AmountItemsSelected { get => amountItemsSelected; set => amountItemsSelected = value; }
  public static bool ActiveFalse { get => activeFalse; set => activeFalse = value; }
  public static bool MustCheck { get => mustCheck; set => mustCheck = value; }

  private void Awake()
  {
    //instanciatedTraill = Instantiate(prefabTraill);
    //instanciatedTraill.SetActive(false);
  }

  private void Update()
  {
    if (mustCheck)
    {
      CheckPuzzle2();
      mustCheck = false;
    }
    
    if (amountItemsSelected == conditionToFinish.Count)
    {
      CheckPuzzle();
      amountItemsSelected = 0;
    }
    
   /* if (PlayerController.DoSuperJump)
    {
      StartCoroutine(ResetWallAndTraill());
      Reset();
    }*/
  }

  void CheckPuzzle()
  {
    for (int i = 0; i < conditionToFinish.Count; i++)
    {
      if(conditionToFinish[i].GetInstanceID() == itemsSelected[i].GetInstanceID())
      {
        playerResult.Add(itemsSelected[i]);
      }
      else
      {
        Reset();
        finishMissionSFX.Play();
      }
    }

    if (playerResult.Count == conditionToFinish.Count)
    {
      GameManager.GameObjects[0].GetComponent<PlayerController>().ChangeJumpForce(7f);
      //instanciatedTraill.transform.SetParent(GameManager.GameObjects[0].transform);
      //instanciatedTraill.transform.localPosition = traillPosition;
      //instanciatedTraill.SetActive(true);
      ParticleSystem particle = GameManager.GameObjects[0].GetComponentInChildren<ParticleSystem>();
      var main = particle.main;
      var emission = GameManager.GameObjects[0].GetComponentInChildren<ParticleSystem>().emission;
      emission.rateOverTime = 160;
      main.maxParticles = 300;
      wallToEliminate.SetActive(false);
      finishMissionSFX.Play();
      activeFalse = true;
    }
  }

  void Reset()
  {
    for (int i = 0; i < conditionToFinish.Count; i++)
    {
      itemsSelected[i].GetComponent<PlatformsPuzzle3>().ResetPositionOfPlattforms();
    }
    StartCoroutine(DelayToClearList());
  }

  void CheckPuzzle2()
  {
    if (conditionToFinish[j].GetInstanceID() == itemsSelected[j].GetInstanceID())
    {
      j++;
    }
    else
    {
      for (int i = 0; i <= j; i++)
      {
        itemsSelected[i].GetComponent<PlatformsPuzzle3>().ResetPositionOfPlattforms();
      }
      finishMissionSFX.Play();
      itemsSelected.Clear();
      playerResult.Clear();
      amountItemsSelected = 0;
      j = 0;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag.Equals("Player") && cont !=1)
    {
      StartCoroutine(Type());
      textDisplay.GetComponent<TextFader>().Fade();
    }
  }
  
  IEnumerator DelayToClearList()
  {
    yield return new WaitForSeconds(0.35f);
    itemsSelected.Clear();
    playerResult.Clear();
    j = 0;
    GameManager.GameObjects[0].GetComponent<PlayerController>().ChangeJumpForce(4f);
    //PlayerController.DoSuperJump = false;
    yield return null;
  }

  IEnumerator ResetWallAndTraill()
  {
    yield return new WaitForSeconds(1.8f);
    //instanciatedTraill.SetActive(false);
    yield return new WaitForSeconds(1.2f);
    wallToEliminate.SetActive(true);
  }
  
  IEnumerator Type()
  {
    cont++;
    textDisplay.GetComponent<Text>().text = "";
    foreach (char letter in sentences[index].ToCharArray())
    {
      textDisplay.GetComponent<Text>().text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }
    yield return new WaitForSeconds(TextExitTime);
    textDisplay.GetComponent<TextFader>().Fade();
  }
}