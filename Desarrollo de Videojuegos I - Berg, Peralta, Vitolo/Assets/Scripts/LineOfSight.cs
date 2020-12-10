using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float range;
    private float angleOfSight;
    public float angleMaxOfSight;
    public LayerMask layer;

    private float _distance = 0;
    private Vector3 _difference = Vector3.zero;
    
    public bool IsInSight(GameObject target)
    {
        Vector3 diff = (target.transform.position - transform.position);
        float distance = diff.magnitude;
    
        if(distance > range) {return false;}
        angleOfSight = Vector3.Angle(transform.forward, diff.normalized); 
        if(angleOfSight > angleMaxOfSight /2){return false;} 

        if (Physics.Raycast(transform.position, diff.normalized,distance, layer))
        {
            return false; 
        }
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * range);
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0,angleMaxOfSight /2,0)* transform.forward * range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0,-angleMaxOfSight /2,0)* transform.forward * range);
    }
}