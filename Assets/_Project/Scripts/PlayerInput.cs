using UnityEngine;

public class PlayerInput : IInputService
{
    public Vector3 GetInputPosition() => Input.mousePosition;
}