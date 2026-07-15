using UnityEngine;

public class PlayerInput : IInputService
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    public Vector3 GetInputPosition() => Input.mousePosition;
    
    public Vector3 GetInputWorldPosition() => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    public bool PullObject() => Input.GetMouseButton(LeftMouseButton);
    
    public bool ThrowObject() => Input.GetMouseButtonUp(LeftMouseButton);

    public bool BlowUp() => Input.GetMouseButtonDown(RightMouseButton);

    public bool ChangeCamera() => Input.GetKeyDown(KeyCode.Space);
    
    public Ray GetRayFromScreenPoint() => Camera.main.ScreenPointToRay(GetInputPosition());
}