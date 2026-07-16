using UnityEngine;

public class PlayerCharacterController : Controller
{
    private Character _character;

    public PlayerCharacterController(Character character)
    {
        _character = character;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        _character.SetMoveDirection(inputDirection);
        _character.SetRotationDirection(inputDirection);
    }
}
