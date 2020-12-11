using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteCutscene : MonoBehaviour
{
    [SerializeField] private CutscenePlayerLvl4 cutsceneRef;
    [SerializeField] private GameObject _cinematicCamera;
    [SerializeField] private GameObject _npcRef;
    [SerializeField] private AudioSource _musicLvl;
    private Camera _mainCameraRef;

    private void Awake()
    {
        _mainCameraRef = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _npcRef.SetActive(true);
            _cinematicCamera.SetActive(true);
            other.gameObject.SetActive(false);

            GameObject cameraRef = GameManager.GameObjects[0];
            cutsceneRef.AssignReferences(_npcRef ,cameraRef);

            cutsceneRef.ExecuteCutscene = true;
            _musicLvl.Play();
        }
    }
}
