using UnityEngine;

public class Mover : ChangerObjectRigitbody, ITransformable
{
    [SerializeField] protected float Speed;

    public void ApplyMovement(Vector3 direction) => 
        Rigidbody.MovePosition(Rigidbody.position + direction.normalized * (Speed * Time.deltaTime));
}
