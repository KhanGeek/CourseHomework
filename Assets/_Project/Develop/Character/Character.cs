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

    public float CurrentVelocity => _agent.desiredVelocity.magnitude;

    private void Awake()
    {
        _health = new Health(100, 0.3f);
    }

    private void Start()
    {
        _healthVisual.SetHealth(_health);
    }
    
    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        _characterVisual.Hit();
    }

    public void Heal(float healAmount) => _health.Heal(healAmount);
    
    public void SetDestination(Vector3 destination) => _agent.SetDestination(destination);

    public bool EnoughCornersCountInPath() => _agent.path.corners.Length > MinCornersCount;
    
    public bool IsWounded => _health.IsWounded;
    
    public bool IsDead => _health.IsDead;

    public Vector3 GetEndPointPosition() => _agent.path.corners[_agent.path.corners.Length - 1];
}
