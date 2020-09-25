using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerRef = null;
    [SerializeField] private float distanceBetweenPlayer = 3;
    [SerializeField] private float sensitivity;
    [SerializeField] private Camera camera = null;
    private Transform cameraTransform = null;
    private const float minXAngle = 12f;
    private const float maxXAngle = 50f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float minFov = 20f;
    private float maxFov = 50f;
 
    private void Start()
    {
        cameraTransform = this.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RelativePositionFromMouse();
        CalculateCameraPosition();
        CameraZoom();
    }

    private void RelativePositionFromMouse()
    {
        currentX -= Input.GetAxis("Mouse Y");
        currentY += Input.GetAxis("Mouse X");
        currentX = Mathf.Clamp(currentX, minXAngle, maxXAngle);
    }

    private void CalculateCameraPosition()
    {      
        Vector3 direction = new Vector3(0, 0, -distanceBetweenPlayer);
        Quaternion rotation = Quaternion.Euler(currentX,currentY ,0 );
        cameraTransform.position = playerRef.transform.position + rotation * direction;
        cameraTransform.LookAt(playerRef.transform.position + new Vector3(0,1,0));
    }
    
    void CameraZoom()
    {
        var fov = camera.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity; 
        fov = Mathf.Clamp(fov, minFov, maxFov);
        camera.fieldOfView = fov;
    }
}