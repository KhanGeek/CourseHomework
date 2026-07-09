using UnityEngine;

public interface IGrabbable
{
    bool IsGrabbed();
    void StartGrab(Vector3 position);
    void UpdateGrab(RaycastHit hit);
}
