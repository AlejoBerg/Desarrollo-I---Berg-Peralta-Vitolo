using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayerLvl4 : MonoBehaviour
{
    private Transform _transformRef;
    private WaypointsController _wpControllerRef;
    private Rigidbody _rbRef;
    private Animator _animatorRef;
    private bool executeCutscene = false;

    public bool ExecuteCutscene { get => executeCutscene; set => executeCutscene = value; }

    void Update()
    {
        print(executeCutscene);
        if(executeCutscene == true)
        {
            MoveNpc();
        }
    }

    public void AssignReferences(Transform transformRef, WaypointsController wpRef, Rigidbody rbRef, Animator animatorRef)
    {
        _transformRef = transformRef;
        _wpControllerRef = wpRef;
        _rbRef = rbRef;
        _animatorRef = animatorRef;
        StartCoroutine(StopPlayer());
    }

    private void MoveNpc()
    {
        _animatorRef.SetInteger("Speed", 1);
        var direction = _wpControllerRef.GetNextPosition();
        _rbRef.velocity = direction * 1.5f;
        _transformRef.forward = Vector3.Lerp(_transformRef.forward, direction, 5 * Time.deltaTime);
    }

    IEnumerator StopPlayer()
    {
        yield return new WaitForSeconds(28f);
        executeCutscene = false;
        _animatorRef.SetInteger("Speed", 0);
        _rbRef.velocity = Vector3.zero;
        _rbRef.Sleep();
    }
}
