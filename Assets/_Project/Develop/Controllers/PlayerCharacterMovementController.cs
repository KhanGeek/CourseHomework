using UnityEngine;

public class PlayerCharacterMovementController : ICharacterMovomentController
{
    private Character _character;
    private PlayerInput _playerInput;

    private bool _isMovement;

    public PlayerCharacterMovementController(Character character, PlayerInput playerInput)
    {
        _character = character;
        _playerInput = playerInput;
    }

    public bool IsMove => _isMovement;

    public void Update()
    {
        if (_playerInput == null)
            return;

        if (_character.IsDead)
            return;

        if (_playerInput.HasAppearedNextTargetPoint())
            SetNextTargetPoint();

        if (_character.EnoughCornersCountInPath() == false && _isMovement)
            _isMovement = false;
    }

    private void SetNextTargetPoint()
    {
        if (_playerInput.TryGetNextTargetPoint(out Vector3 targetPoint))
        {
            _character.SetDestination(targetPoint);
            _isMovement = true;
        }
    }
}
