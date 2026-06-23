using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Moving : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private float _deadZone = 0.05f;
    
    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (inputDirection.magnitude > _deadZone)
        {
            _rigidbody.velocity = inputDirection.normalized * _speed;
            _rigidbody.MoveRotation(Quaternion.LookRotation(inputDirection));
        }
    }

    public void SetSpeed(float speed)
    {
        if(speed <= 0)
            return;
        
        _speed = speed;
    }
}
