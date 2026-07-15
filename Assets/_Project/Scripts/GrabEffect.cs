using UnityEngine;

public class GrabEffect
{
    private IGrabbable _grabbable;
    private Plane _grabPlane;

    public GrabEffect(IGrabbable grabbable) => _grabbable = grabbable;

    public bool IsGrabbableObject => _grabbable != null;

    public void Start()
    {
        if (IsGrabbableObject==false)
            return;

        _grabPlane = new Plane(Vector3.up, _grabbable.GetPosition());
        _grabbable.StartGrab();
    }

    public void Update(Ray ray)
    {
        if (IsGrabbableObject==false)
            return;

        if (_grabPlane.Raycast(ray, out float distance))
        {
            Vector3 position = ray.GetPoint(distance);
            _grabbable.UpdateGrab(position);
        }
    }
    
    public void Stop()
    {
        if (IsGrabbableObject)
            _grabbable.StopGrab();
    }
}
