using UnityEngine;

public class Raycaster
{
    public RaycastHit EmitRay(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }

    public void StartEffect(IRaycastEffect effect, RaycastHit hit) => effect.Lounch(hit);
}
