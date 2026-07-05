using UnityEngine;

public class Rotator : ChangerObjectRigitbody
{
    protected override void Update()
    {
        if (_inputBehavior.IsMoving(out Vector3 direction))
            _rigidbody.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
    }
}
