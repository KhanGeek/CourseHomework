using UnityEngine;

public class Mover : ChangerObjectRigitbody
{
    [SerializeField] protected float Speed;
   
    protected override void FixedUpdate()
    {
        if (_inputBehavior.IsMoving(out Vector3 direction))
            _rigidbody.MovePosition(
                _rigidbody.position + direction.normalized * (Speed * Time.fixedDeltaTime));
    }
}
