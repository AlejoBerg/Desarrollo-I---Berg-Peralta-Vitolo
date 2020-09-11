using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraController : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    public float lerpValue;
    public float sensibilityX;
    public float sensibilityY;
    private float y;
    
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        y -= Input.GetAxis("Mouse Y") * sensibilityY;
        y = Mathf.Clamp(y, 1, 2); //Limito la camara en el eje Y
        
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset.y = y;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilityX, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
