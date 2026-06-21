using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed;

    private Vector3 _offset;

    private void Start() => _offset = transform.position;

    private void LateUpdate()
    {
       // transform.RotateAround(_target.position, Vector3.up, _cameraSpeed * Time.deltaTime);
        
        transform.position = _target.position + _offset;
    }
}
