using UnityEngine;
using UnityEngine.AI;

public class CharacterMovementAgentController
{
    private const int MinCornersCount = 1;
    private NavMeshAgent _agent;
    private IInputService _inputService;

    public CharacterMovementAgentController(NavMeshAgent agent, IInputService inputService)
    {
        _agent = agent;
        _inputService = inputService;
    }

    public void Update()
    {
        if (_inputService.HasAppearedNextTargetPoint())
        {
            if (_inputService.TryGetNextTargetPoint(out Vector3 targetPoint))
            {
                _agent.SetDestination(targetPoint);
            }
        }

        if (EnoughCornersCountInPath()==false)
            _inputService.DestroyVisualTargetPoint();
    }

    private bool EnoughCornersCountInPath() => _agent.path.corners.Length > MinCornersCount;
}
