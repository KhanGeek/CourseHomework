using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrolBehavior : IBehavior
{
    private Queue<Vector3> _waypoints;
    private Transform _characterTransform;
    private Vector3 _currentWaypoint;

    public WaypointPatrolBehavior(Queue<Vector3> waypoints, Transform characterTransform)
    {
        _waypoints = waypoints;
        _characterTransform = characterTransform;
        
        SetNextWaypoint();
    }

    private void SetNextWaypoint()
    {
        _currentWaypoint = _waypoints.Dequeue();
        _waypoints.Enqueue(_currentWaypoint);
    }

    public Vector3 Update()
    {
        Vector3 direction = _currentWaypoint - _characterTransform.position;

        if (direction.magnitude < Constants.MinDistanceBetweenPoints)
        {
            SetNextWaypoint();
        }
        
        return direction;
    }
}
