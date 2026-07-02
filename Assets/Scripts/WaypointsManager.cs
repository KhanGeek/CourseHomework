using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public static List<Transform>  Waypoints;

    static WaypointsManager()
    {
        Waypoints = new List<Transform>();
    }
}
