using UnityEngine;

public class PlayerInput : InputBehavior
{
    private void Update() => Direction = 
        new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
}
