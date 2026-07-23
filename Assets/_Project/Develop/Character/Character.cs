using System;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamageble
{
    private CharacterMovementAgentController _movementController;

    [SerializeField] private HealthVisual _healthVisual;
    private Health _health;
    
    [SerializeField] private GameObject _inputServiceGameObject;
    private IInputService _inputService;
    
    [SerializeField] private CharacterVisual _characterVisual;
    
    [SerializeField] private NavMeshAgent _agent;

    public float CurrentVelocity => _agent.desiredVelocity.magnitude;

    private void Awake()
    {
        _inputService = _inputServiceGameObject.GetComponent<IInputService>();
        
        if(_inputService == null)
            Debug.LogError("Input service not found");
        
        _movementController = new CharacterMovementAgentController(_agent, _inputService);

        _health = new Health(100, 30);
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
}
