using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraController : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    public float lerpValue;
    public float sensibility;
    
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
