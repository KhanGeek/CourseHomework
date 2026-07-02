using UnityEngine;

public class Mover : ChangerObjectTransform
{
    [SerializeField] protected float _speed;
   
    protected override void FixedUpdate()
    {
        if (_inputBehavior.IsMoving(out Vector3 direction))
            _rigidbody.MovePosition(
                _rigidbody.position + direction.normalized * (_speed * Time.fixedDeltaTime));
    }
}
