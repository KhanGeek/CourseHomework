using UnityEngine;

public class Raycaster
{
    public Vector3 EmitRay(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
