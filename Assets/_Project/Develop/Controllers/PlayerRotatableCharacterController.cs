using UnityEngine;

public class PlayerRotatableCharacterController : Controller
{
    private IRotatable _rotatable;

    public PlayerRotatableCharacterController(IRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        _rotatable.SetRotationDirection(inputDirection);
    }
}
