using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrolMovementBehavior : IMovementBehavior
{
    private Queue<Vector3> _waypoints;
    private Transform _characterTransform;
    private Vector3 _currentWaypoint;
    
    private List<ITransformable> _transformables;

    public WaypointPatrolMovementBehavior(Queue<Vector3> waypoints, Transform characterTransform, List<ITransformable> transformables)
    {
        _waypoints = waypoints;
        _characterTransform = characterTransform;
        _transformables = transformables;
        
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

    public void Step()
    {
        Vector3 direction = _currentWaypoint - _characterTransform.position;

        if (direction.magnitude < Constants.MinDistanceBetweenPoints)
        {
            SetNextWaypoint();
        }
        
        foreach (ITransformable transformable in _transformables) 
            transformable.ApplyMovement(direction);
    }
}
