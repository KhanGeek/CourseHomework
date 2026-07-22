using UnityEngine;
using UnityEngine.AI;

public class CharacterAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    private AgentMover _mover;
    private DirectionalRotator _rotator;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotateSpeed;
    
    [SerializeField] private Transform _target;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _mover = new AgentMover(_agent, _movementSpeed);
        _rotator = new DirectionalRotator(transform, _rotateSpeed);
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void SetDestination(Vector3 destination) => _mover.SetDestination(destination);

    public void StopMove() => _mover.Stop();

    public void ResumeMove() => _mover.Resume();

    public bool TryGetPath(Vector3 target, NavMeshPath path) => 
        NavMeshUtils.TryGetPath(_agent, target, path);
}
