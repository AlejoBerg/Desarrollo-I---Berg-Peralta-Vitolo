using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteCutscene : MonoBehaviour
{
    [SerializeField] private CutscenePlayerLvl4 cutsceneRef;
    [SerializeField] private GameObject _cinematicCamera;
    [SerializeField] private GameObject _npcRef;
    private Camera _mainCameraRef;

    private void Awake()
    {
        _mainCameraRef = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("triggereo");
        if(other.gameObject.tag == "Player")
        {
            _npcRef.SetActive(true);
            _cinematicCamera.SetActive(true);
            other.gameObject.SetActive(false);

            Transform refTransform = _npcRef.GetComponent<Transform>();
            WaypointsController wpRef = _npcRef.GetComponent<WaypointsController>();
            Rigidbody rbRef = _npcRef.GetComponent<Rigidbody>();
            Animator animatorRef = _npcRef.GetComponent<Animator>();

            cutsceneRef.AssignReferences(refTransform, wpRef, rbRef, animatorRef);

            cutsceneRef.ExecuteCutscene = true;
        }
    }
}
