using UnityEngine;
using UnityEngine.AI;

public class AgentCharacterAgroController : Controller
{
    private CharacterAgent _character;
    
    private Transform _target;

    private float _agroDistance;
    private float _minDistanceToTarget;

    private float _idleTimer;
    private float _timeToIdle;

    private NavMeshPath _pathToTarget = new NavMeshPath();

    public AgentCharacterAgroController(
        CharacterAgent character, 
        Transform target, 
        float agroDistance, 
        float minDistanceToTarget, 
        float timeToIdle)
    {
        _character = character;
        _target = target;
        _agroDistance = agroDistance;
        _minDistanceToTarget = minDistanceToTarget;
        _timeToIdle = timeToIdle;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _idleTimer -= deltaTime;

        _character.SetRotationDirection(_character.CurrentVelocity);
        
        if (_character.TryGetPath(_target.position, _pathToTarget))
        {
            float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);
            
            if(IsTargetReached(distanceToTarget))
                _idleTimer = _timeToIdle;

            if (InAgroRange(distanceToTarget) && IdleTimerIsUp())
            {
                _character.ResumeMove();
                _character.SetDestination(_target.position);
                return;
            }
        }
        
        _character.StopMove();
    }
    
    private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
    
    private bool InAgroRange(float distanceToTarget) => distanceToTarget <= _agroDistance;

    private bool IdleTimerIsUp() => _idleTimer <= 0;
}
