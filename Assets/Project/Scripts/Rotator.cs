using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _angleStep = 20f;
    [SerializeField] private bool _limitRotation90Deg;
    
    private float _currentAngle;

    private void Awake() => _currentAngle = transform.localRotation.eulerAngles.y;

    public void TurnLeft() => Turn(_angleStep * Time.deltaTime);

    public void TurnRight() => Turn(-_angleStep * Time.deltaTime);

    private void Turn(float delta)
    {
        _currentAngle = NormalizeYRotation(_currentAngle + delta);
        
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x,
            _currentAngle, transform.localRotation.eulerAngles.z);
    }

    private float NormalizeYRotation(float angle) =>
        _limitRotation90Deg
            ? Mathf.Clamp(angle, -90f, 90f)
            : Mathf.Repeat(angle, 360f);
}