using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void Start() => WaypointsManager.Waypoints.Add(transform);
}
