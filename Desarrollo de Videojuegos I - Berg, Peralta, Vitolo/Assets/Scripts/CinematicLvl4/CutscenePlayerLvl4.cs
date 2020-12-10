using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayerLvl4 : MonoBehaviour
{
    [SerializeField] private CanvasFade fadeOutImage = null;

    private Transform _transformRef;
    private WaypointsController _wpControllerRef;
    private Rigidbody _rbRef;
    private Animator _animatorRef;
    private GameObject _cameraRef;
    private bool executeCutscene = false;

    public bool ExecuteCutscene { get => executeCutscene; set => executeCutscene = value; }

    void Update()
    {
        if(executeCutscene == true)
        {
            MoveNpc();
        }
    }

    public void AssignReferences(GameObject npcReference, GameObject cameraRef)
    {

        _transformRef = npcReference.transform;
        _wpControllerRef = npcReference.GetComponent<WaypointsController>();
        _rbRef = npcReference.GetComponent<Rigidbody>();
        _animatorRef = npcReference.GetComponent<Animator>();
        _cameraRef = cameraRef;
        fadeOutImage.ChangeStartEndAlpha(1, 0);

        StartCoroutine(StopPlayer());
    }

    private void MoveNpc()
    {
        fadeOutImage.DoFade();
        _animatorRef.SetInteger("Speed", 1);
        var direction = _wpControllerRef.GetNextPosition();
        _rbRef.velocity = direction * 1.5f;
        _transformRef.forward = Vector3.Lerp(_transformRef.forward, direction, 5 * Time.deltaTime);

        StartCoroutine(Delay(18));
        print("ejecutando fade despues del delay");
        
    }

    IEnumerator StopPlayer()
    {
        yield return new WaitForSeconds(25f);
        fadeOutImage.ChangeStartEndAlpha(0,1);
        fadeOutImage.DoFade();
        executeCutscene = false;
        _animatorRef.SetInteger("Speed", 0);
        _rbRef.velocity = Vector3.zero;
        _rbRef.Sleep();
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
