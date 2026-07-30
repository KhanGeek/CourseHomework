using System;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamageable, ITreatable
{
    private const int MinCornersCount = 1;
    
    [SerializeField] private HealthVisual _healthVisual;
    private Health _health;
    
    [SerializeField] private CharacterVisual _characterVisual;
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float _jumpSpeed;
    [SerializeField] private AnimationCurve _jumpCurve;
    
    private CharacterJumpController _characterJumpController;

    public float CurrentVelocity => _agent.desiredVelocity.magnitude;

    public bool IsJump => _characterJumpController.InProcess;

    private void Awake()
    {
        _health = new Health(100, 0.3f);
        _characterJumpController = new CharacterJumpController(_jumpSpeed, _agent, this, _jumpCurve);
    }

    private void Start()
    {
        _healthVisual.SetHealth(_health);
    }

    private void Update()
    {
        if (IsOnMeshLink(out OffMeshLinkData offMeshLinkData))
        {
            if (IsJump == false)
            {
                _characterJumpController.Jump(offMeshLinkData);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        _characterVisual.Hit();
    }

    public void Heal(float healAmount) => _health.Heal(healAmount);
    
    public void SetDestination(Vector3 destination)
    {
        if(IsJump)
            return;
        
        _agent.SetDestination(destination);
    }

    public bool EnoughCornersCountInPath() => _agent.path.corners.Length > MinCornersCount;
    
    public bool IsWounded => _health.IsWounded;
    
    public bool IsDead => _health.IsDead;

    public Vector3 GetEndPointPosition() => _agent.path.corners[_agent.path.corners.Length - 1];
    
    private bool IsOnMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if (_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }
}
