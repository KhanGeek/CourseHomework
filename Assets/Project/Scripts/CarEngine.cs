using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private Rigidbody _movable;
    [SerializeField] private Transform _currentOrientation;
    
    private float _horizontalInput;
    private float _verticalInput;

    private bool _onGround;

    private void Awake()
    {
        _movable.maxLinearVelocity = _maxSpeed;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _onGround = Physics.Raycast(_movable.position, Vector3.down, out RaycastHit groundHit, 0.6f);

        _currentOrientation.Rotate(Vector3.up * _horizontalInput * _rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_movable.position, _currentOrientation.forward);
    }

    private void FixedUpdate()
    {
        if (_onGround)
        {
            _movable.AddForce(_currentOrientation.forward * _verticalInput * _speed, ForceMode.Acceleration);

            if (_verticalInput < 0.05f)
            {
                _movable.velocity *= 0.95f;
            }
        }
        else
        {
            _movable.AddForce(_currentOrientation.forward * _speed / 5, ForceMode.Acceleration);
        }
    }
}
