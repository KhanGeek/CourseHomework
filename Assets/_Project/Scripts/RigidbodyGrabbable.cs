using System;
using UnityEngine;

public class RigidbodyGrabbable : MonoBehaviour, IGrabbable
{
    [SerializeField] private Rigidbody _rigidbody;

    private bool _grabbed;
    private Vector3 _startGrabbedPosition;
    private float _startGrabbedTimer = 0.5f;
    private float _grabbedTimer;

    private void Update()
    {
        if (_grabbed == false)
            return;

        _grabbedTimer -= Time.deltaTime;

        if (_grabbedTimer <= 0f)
            StopGrab();
    }

    public bool IsGrabbed() => _grabbed;
    
    public void StartGrab(Vector3 position)
    {
        if (_grabbed)
            return;
        
        _startGrabbedPosition = position;
        
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _grabbed = true;
    }

    public void UpdateGrab(RaycastHit hit)
    {
        if (_grabbed == false)
            return;
        
        /*if (_grabbedPlane.Raycast(ray, out float distance))
        {
            _rigidbody.position = ray.GetPoint(distance);
        }*/
        
        _rigidbody.MovePosition(hit.point);

        _grabbedTimer = _startGrabbedTimer;
    }

    private void StopGrab()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _grabbed = false;
    }
}
