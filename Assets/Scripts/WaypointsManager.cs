using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public static List<Transform>  Waypoints = new List<Transform>();

    public static void AddWaypoint(Transform transform) => Waypoints.Add(transform);
}
