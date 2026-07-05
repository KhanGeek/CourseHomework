using UnityEngine;

public class Mover : ChangerObjectRigitbody
{
    [SerializeField] protected float Speed;

    protected override void Update()
    {
        if (InputBehavior.IsMoving(out Vector3 direction))
            Rigidbody.MovePosition(
                Rigidbody.position + direction.normalized * (Speed * Time.deltaTime));
    }
}
