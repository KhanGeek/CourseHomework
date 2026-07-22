using UnityEngine;
using UnityEngine.AI;

public class DirectionalMovableAgroController : Controller
{
    private const int MinCornersCountInPathToMove = 2;
    private const int StartCornerIndex = 0;
    private const int TargetCornerIndex = 1;
    
    private IMovable _movable;
    
    private Transform _target;

    private float _agroDistance;
    private float _minDistanceToTarget;
    
    private NavMeshQueryFilter _queryFilter;

    private float _idleTimer;
    private float _timeToIdle;

    private NavMeshPath _pathToTarget = new NavMeshPath();


    public DirectionalMovableAgroController(IMovable movable, Transform target, float agroDistance, float minDistanceToTarget, NavMeshQueryFilter queryFilter, float timeToIdle)
    {
        _movable = movable;
        _target = target;
        _agroDistance = agroDistance;
        _minDistanceToTarget = minDistanceToTarget;
        _queryFilter = queryFilter;
        _timeToIdle = timeToIdle;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _idleTimer -= deltaTime;

        if (NavMeshUtils.TryGetPath(_movable.Position, _target.position, _queryFilter, _pathToTarget))
        {
            float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

            if (IsTargetReached(distanceToTarget))
                _idleTimer = _timeToIdle;

            if (InAgroRange(distanceToTarget)
                && EnoughCornersInPath(_pathToTarget)
                && IdleTimerIsUp())
            {
                _movable.SetMoveDirection(_pathToTarget.corners[TargetCornerIndex]-_pathToTarget.corners[StartCornerIndex]);
                return;
            }
        }
        
        _movable.SetMoveDirection(Vector3.zero);
    }
    
    private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
    
    private bool InAgroRange(float distanceToTarget) => distanceToTarget <= _agroDistance;
    
    private bool EnoughCornersInPath(NavMeshPath path)=> path.corners.Length >= MinCornersCountInPathToMove;

    private bool IdleTimerIsUp() => _idleTimer <= 0;
}
