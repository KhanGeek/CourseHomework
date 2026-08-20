using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour, IDamageble
{
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _speed;
    
    private Health _health;
    
    private bool isInitialized;

    public void Initialize(float speed, Health health)
    {
        _speed = speed;
        _health = health;
        
        isInitialized = true;

        GetComponentInChildren<HealthView>().Initialize(_health);//не придумал как сделать красивше(
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isInitialized == false)
            return;
        
        if (_direction.magnitude < 0.1f)
            return;

        _rigidbody.MovePosition(_rigidbody.position + (_direction * _speed * Time.fixedDeltaTime));
        _rigidbody.MoveRotation(Quaternion.LookRotation(_direction));
    }

    public void SetDirection(Vector3 direction) => _direction = direction.normalized;
    
    public void TakeDamage(float damage) => _health.TakeDamage(damage);
}
