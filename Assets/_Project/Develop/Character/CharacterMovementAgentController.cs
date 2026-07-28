using UnityEngine;

public class CharacterMovementAgentController
{
    private const int MinCornersCount = 1;
    
    private Character _character;
    private IInputService _inputService;

    private bool _isMovement;

    public CharacterMovementAgentController(Character character) => _character = character;

    public void ChangeInputService(IInputService inputService) => _inputService = inputService;

    public void Update()
    {
        if (_inputService == null)
            return;

        if (_character.IsDead)
        {
            _inputService.DestroyVisualTargetPoint();
            return;
        }
        
        if (_inputService.HasAppearedNextTargetPoint())
        {
            SetNextTargetPoint();
        }

        if (EnoughCornersCountInPath() == false && _isMovement)
        {
            _inputService.DestroyVisualTargetPoint();
            _isMovement = false;
        }
    }

    private void SetNextTargetPoint()
    {
        if (_inputService.HasAppearedNextTargetPoint())
        {
            if (_inputService.TryGetNextTargetPoint(out Vector3 targetPoint))
            {
                _character.SetDestination(targetPoint);
                _isMovement = true;
            }
        }
    }

    private bool EnoughCornersCountInPath() => _character.GetAgentPath().corners.Length > MinCornersCount;
}
