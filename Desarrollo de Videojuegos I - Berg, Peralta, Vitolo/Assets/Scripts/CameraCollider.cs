using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    [SerializeField] private Transform posCamera;
    RaycastHit hit;
	private Vector3 cameraOffset;
   	void Start ()
    {
	    cameraOffset = posCamera.localPosition;
    }
   	
   	void Update () 
    {
	    if (Physics.Linecast (transform.position, transform.position + transform.localRotation*cameraOffset, out hit))
	    {
		    posCamera.localPosition = new Vector3(0, 0, Vector3.Distance(transform.position, hit.point));
		    Debug.Log("hay colision");
	    } 
	    else
	    {
		    posCamera.localPosition = Vector3.Lerp(posCamera.localPosition,cameraOffset,Time.deltaTime);
		    Debug.Log("no hay colision");
	    }
    }
}
