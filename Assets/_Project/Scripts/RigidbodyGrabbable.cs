using System;
using UnityEngine;

public class RigidbodyGrabbable : MonoBehaviour, IGrabbable
{
    [SerializeField] private Rigidbody _rigidbody;

    private bool _grabbed;

    public bool IsGrabbed() => _grabbed;
    
    public void StartGrab(Vector3 position)
    {
        if (_grabbed)
            return;
        
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _grabbed = true;
    }

    public void UpdateGrab(Vector3 position)
    {
        if (_grabbed == false)
            return;
        
        _rigidbody.MovePosition(position);
    }

    public void StopGrab()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _grabbed = false;
    }
}
