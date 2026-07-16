using UnityEngine;

public class PlayerMovableCharacterController : Controller
{
    private IMovable _movable;

    public PlayerMovableCharacterController(IMovable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        _movable.SetMoveDirection(inputDirection);
    }
}
