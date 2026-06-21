using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _vertikalForce;
    [SerializeField] private PlayerVisual _playerVisualController;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _deadZone = 0.05f;
    private bool _jumping;
    private bool _canJump;
    private Transform _playerVisualTransform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerVisualTransform = _playerVisualController.GetPlayerVisualTransform();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (direction.magnitude > _deadZone)
            _direction = _playerVisualTransform.TransformDirection(direction);

        if (Input.GetButtonDown("Jump"))
            _jumping = true;
    }

    private void FixedUpdate()
    {
        if (_direction.magnitude > _deadZone)
        {
            _rigidbody.AddForce(_direction * _horizontalForce);
        }

        if (_jumping)
        {
            _rigidbody.AddForce(Vector3.up * _vertikalForce, ForceMode.Impulse);
            _playerVisualController.Jump();
            _jumping = false;
        }
    }

   /* private void OnCollisionEnter(Collision other) => _canJump = true;

    private void OnCollisionExit(Collision collision) => _canJump = false;*/

    public Vector3 GetDirection() => _direction;
}