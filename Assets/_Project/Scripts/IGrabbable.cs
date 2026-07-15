using UnityEngine;

public interface IGrabbable
{
    bool IsGrabbed();
    void StartGrab();
    void UpdateGrab(Vector3 nextPosition);
    void StopGrab();
    Vector3 GetPosition();
}
