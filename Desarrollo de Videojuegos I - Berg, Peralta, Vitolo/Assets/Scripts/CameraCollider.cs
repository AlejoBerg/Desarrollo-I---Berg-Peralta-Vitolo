using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public float minDistance = 0f;
	public float maxDistance = 3f;
	public float smooth;
	Vector3 dollyDir;
	float distance; 
	
   	void Awake ()
    {
	    dollyDir = transform.localPosition.normalized;
	    distance = transform.localPosition.magnitude;
    }
   	
   	void Update ()
    {
	    Vector3 desiredCameraPos = transform.TransformPoint(dollyDir * maxDistance);
	    RaycastHit hit;

	    if (Physics.Linecast(transform.position, desiredCameraPos, out hit))
	    {
		    distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
	    }
	    else
	    {
		    distance = maxDistance;
	    }
	    transform.localPosition = Vector3.Lerp( transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
