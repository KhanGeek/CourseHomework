using UnityEngine;

public class Rotator : ChangerObjectTransform
{
    protected override void FixedUpdate()
    {
        if (_inputBehavior.IsMoving(out Vector3 direction))
            _rigidbody.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
    }
}
