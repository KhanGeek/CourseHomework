using UnityEngine;

public class Rotator : ChangerObjectRigitbody, ITransformable
{
    public void ApplyMovement(Vector3 direction) => 
        Rigidbody.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
}
