using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float _torqueForse;
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _deadZone = 0.1f;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Update() => _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    private void FixedUpdate()
    {
        if (_direction.magnitude > _deadZone)
        {
            _rigidbody.MoveRotation(Quaternion.RotateTowards(_rigidbody.rotation,
                Quaternion.Euler(_direction * _torqueForse), _rotateSpeed * Time.fixedDeltaTime));
        }
        else
        {
            _rigidbody.MoveRotation(Quaternion.RotateTowards(_rigidbody.rotation,
                Quaternion.identity, _rotateSpeed * Time.fixedDeltaTime));
        }
    }
}