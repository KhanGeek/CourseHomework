using UnityEngine;
using UnityEngine.AI;

public class CharacterMovementAgentController
{
    private const int MinCornersCount = 1;
    private NavMeshAgent _agent;
    private IInputService _inputService;

    private bool _isMovement;

    public CharacterMovementAgentController(NavMeshAgent agent) => _agent = agent;

    public void ChangeInputService(IInputService inputService) => _inputService = inputService;

    public void Update()
    {
        if (_inputService == null)
            return;

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
                _agent.SetDestination(targetPoint);
                _isMovement = true;
            }
        }
    }

    private bool EnoughCornersCountInPath() => _agent.path.corners.Length > MinCornersCount;
}
