using System;
using UnityEngine;

public class RigidbodyGrabbable : MonoBehaviour, IGrabbable
{
    [SerializeField] private Rigidbody _rigidbody;

    private bool _grabbed;
    
    private float _grabTimer = 0.25f;
    private float _currentGrabTimer;

    [SerializeField] private float _moveSpeed;
    private float _startGrabPositionY;
    private float _yOffset = 1f;
    

    private void Update()
    {
        if (_grabbed)
            _currentGrabTimer -= Time.deltaTime;
        
        if(_currentGrabTimer <= 0)
            StopGrab();
    }
    
    public bool IsGrabbed() => _grabbed;
    
    public void StartGrab(Vector3 position)
    {
        if (_grabbed)
            return;
        
        _startGrabPositionY = _rigidbody.position.y;
        _currentGrabTimer = _grabTimer;
        
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _grabbed = true;
    }

    public void UpdateGrab(Vector3 position)
    {
        if (_grabbed == false)
            return;
        
        _currentGrabTimer = _grabTimer;

        Vector3 nextPosition = new Vector3(position.x, _startGrabPositionY + _yOffset, position.z);
        _rigidbody.MovePosition(Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * _moveSpeed));
    }

    public void StopGrab()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _grabbed = false;
    }
}
