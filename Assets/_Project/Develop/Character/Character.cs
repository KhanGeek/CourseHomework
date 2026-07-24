using System;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamageble
{
    private CharacterMovementAgentController _movementController;

    [SerializeField] private HealthVisual _healthVisual;
    private Health _health;
    
    [SerializeField] private CharacterVisual _characterVisual;
    
    [SerializeField] private NavMeshAgent _agent;

    public float CurrentVelocity => _agent.desiredVelocity.magnitude;

    private void Awake()
    {
        _movementController = new CharacterMovementAgentController(_agent);

        _health = new Health(100, 0.3f);
    }

    private void Start()
    {
        _healthVisual.SetHealth(_health);
    }

    private void Update()
    {
        if (_health.IsDead)
        {
            _characterVisual.Die();
            return;
        }
        
        _movementController.Update();

        if (_health.IsWounded) 
            _characterVisual.SetWounded();
    }
    
    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        _characterVisual.Hit();
    }
    
    public void ChangeInputService(IInputService inputService)
    {
        _movementController.ChangeInputService(inputService);

        if (inputService is PlayerInput && _health.IsDead == false)
            _movementController.Update();
    }
}
