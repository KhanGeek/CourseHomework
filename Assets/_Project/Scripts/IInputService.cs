using UnityEngine;

public interface IInputService
{
    Vector3 GetInputPosition();
    Vector3 GetInputWorldPosition();
    bool PullObject();
    bool ThrowObject();
    bool BlowUp();
    bool ChangeCamera();
    Ray GetRayFromScreenPoint();
}