using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWaypointPatrolBehavior : IIdleBehavior
{
    private List<Transform> _waypoints;
    private int _currentWaypointIndex;

    public void Update(Transform transform, ref Vector3 direction)
    {
        if (_waypoints == null)
        {
            _waypoints = WaypointsManager.Waypoints;
            _currentWaypointIndex = 0;
        }

        direction = _waypoints[_currentWaypointIndex].position - transform.position;

        if (direction.magnitude < Constants.MinDistance)
        {
            if (_waypoints.Count == _currentWaypointIndex + 1)
            {
                _currentWaypointIndex = 0;
            }
            else
            {
                _currentWaypointIndex++;
            }
        }
    }
}
