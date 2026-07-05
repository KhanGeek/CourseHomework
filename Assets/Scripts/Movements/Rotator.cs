using UnityEngine;

public class Rotator : ChangerObjectRigitbody
{
    protected override void Update()
    {
        if (InputBehavior.IsMoving(out Vector3 direction))
            Rigidbody.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
    }
}
