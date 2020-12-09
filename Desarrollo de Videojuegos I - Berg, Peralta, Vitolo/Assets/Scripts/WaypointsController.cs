using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsController : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private int smoothnessTurn = 1;
    private int movementOrientation = 1;
    private int nextWaypoint = 0;
    private GameObject objectToMoveRef;


    public Vector3 GetNextPosition()
    {
        var nextPoint = _wayPoints[nextWaypoint];
        var nextPointPosition = nextPoint.position;
        Vector3 direction = nextPointPosition - transform.position;

        if(direction.magnitude < smoothnessTurn)
        {
            if(nextWaypoint + 1 < _wayPoints.Length)
            {
                nextWaypoint += movementOrientation;
            }
        }
        return direction.normalized;
    }

}
