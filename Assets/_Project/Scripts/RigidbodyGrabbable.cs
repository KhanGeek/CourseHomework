using System;
using UnityEngine;

public class RigidbodyGrabbable : MonoBehaviour, IGrabbable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _yOffset = 1f;
    [SerializeField] private float _moveSpeed;

    private bool _grabbed;

    public bool IsGrabbed() => _grabbed;
    
    public void StartGrab()
    {
        if (_grabbed)
            return;
        
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _grabbed = true;
        
        _rigidbody.position=new  Vector3(_rigidbody.position.x, _rigidbody.position.y+_yOffset, _rigidbody.position.z);
    }

    public void UpdateGrab(Vector3 nextPosition)
    {
        if (_grabbed == false)
            return;

        nextPosition.y = _rigidbody.position.y;
        _rigidbody.MovePosition(Vector3.Lerp(_rigidbody.position, nextPosition, Time.deltaTime * _moveSpeed));
    }

    public void StopGrab()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _grabbed = false;
    }

    public Vector3 GetPosition() => _rigidbody.position;
}
