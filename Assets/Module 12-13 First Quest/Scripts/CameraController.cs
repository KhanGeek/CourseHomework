using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed;
    [SerializeField]private Rigidbody _playerRigidbody;

    private Vector3 _offset;

    private void Start() => _offset = transform.position;

    private void LateUpdate()
    {
        transform.position = _target.position + _target.rotation*_offset;
        transform.LookAt(_target);
    }
}
