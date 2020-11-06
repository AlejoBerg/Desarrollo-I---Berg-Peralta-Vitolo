using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIntoBuilding : MonoBehaviour
{
    [SerializeField] private AudioSource audioToDecreaseWhenCollide = null;
    [SerializeField] private AudioSource audioToIncreaseWhenCollide = null;
    [SerializeField] private float newCameraDistanceFromPlayer = 0;

    private Camera cameraRef = null;
    private ThirdCameraController thirdPersonCamRef;
    private float previousDistanceFromPlayer = 0;
    
    private void Start()
    {
        cameraRef = Camera.main;
        thirdPersonCamRef = cameraRef.GetComponent<ThirdCameraController>();
        previousDistanceFromPlayer = thirdPersonCamRef.GetCurrentDistanceToPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            thirdPersonCamRef.ChangeDistanceToPlayer(newCameraDistanceFromPlayer);
            audioToDecreaseWhenCollide.Stop();
            audioToIncreaseWhenCollide.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            thirdPersonCamRef.ChangeDistanceToPlayer(previousDistanceFromPlayer);
            audioToDecreaseWhenCollide.Play();
            audioToIncreaseWhenCollide.Stop();
        }
    }
}
