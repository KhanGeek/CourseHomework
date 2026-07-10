using UnityEngine;

public class GrabEffect : IRaycastEffect
{
    private IGrabbable _grabbable;
    
    public bool IsGrabbableObject => _grabbable != null;

    public void Lounch(RaycastHit hit)
    {
        if (_grabbable == null)
            _grabbable = hit.collider.GetComponent<IGrabbable>();

        if (_grabbable != null)
        {
            if (_grabbable.IsGrabbed() == false)
                _grabbable.StartGrab(hit.point);
            else
            {
                _grabbable.UpdateGrab(hit.point);
            }
        }
    }
}
