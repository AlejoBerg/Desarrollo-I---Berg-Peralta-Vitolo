using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private Vector3 offset = Vector3.zero;
    private bool followingTarget = false;
    private GameObject targetRef;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            targetRef = other.gameObject;
            followingTarget = true;
        }
    }

    private void Update()
    {
        if(followingTarget == true)
        {
            transform.position = targetRef.transform.position + offset;
        }
    }
}
