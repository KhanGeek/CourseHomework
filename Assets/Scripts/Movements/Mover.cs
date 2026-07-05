using UnityEngine;

public class Mover : ChangerObjectRigitbody
{
    [SerializeField] protected float Speed;

    protected override void Update()
    {
        if (_inputBehavior.IsMoving(out Vector3 direction))
            _rigidbody.MovePosition(
                _rigidbody.position + direction.normalized * (Speed * Time.deltaTime));
    }
}
