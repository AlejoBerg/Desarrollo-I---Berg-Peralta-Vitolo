using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraController : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    public float lerpValue;
    public float sensibility;
    private float y;
    
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        y -= Input.GetAxis("Mouse Y");
        y = Mathf.Clamp(y, 1, 6); //Limito la camara en el eje Y
        
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset.y = y;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
