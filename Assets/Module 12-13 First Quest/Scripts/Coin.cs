using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    private float _rotationSpeed;
    private float _minRotationSpeed = 90f;
    private float _maxRotationSpeed = 150f;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
        _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
