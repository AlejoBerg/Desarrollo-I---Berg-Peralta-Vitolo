using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] public GameObject playerRef;

    private Transform cameraTransform;
    private Camera camera;

    private const float minXAngle = 0f;
    private const float maxXAngle = 50f;
    private float distanceBetweenPlayer = 10f;
    private float currentX = 0f;
    private float currentY = 0f;

    private void Start()
    {
        cameraTransform = this.transform;
        camera = Camera.main;
    }

    private void Update()
    {
        RelativePositionFromMouse();
        CalculateCameraPosition();
    }

    private void RelativePositionFromMouse()
    {
        currentX -= Input.GetAxis("Mouse Y");
        currentY += Input.GetAxis("Mouse X");
        currentX = Mathf.Clamp(currentX, minXAngle, maxXAngle);
        //playerRef.transform.rotation = Quaternion.Euler(0, currentY, 0);
    }

    private void CalculateCameraPosition()
    {
        Vector3 direction = new Vector3(0, 0, -distanceBetweenPlayer);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        cameraTransform.position = playerRef.transform.position + rotation * direction; //Pongo la camara arriba del player, luego le doy la rotacion y luego lo alejo por una constante
        cameraTransform.LookAt(playerRef.transform.position);
    }
}
