using UnityEngine;

public interface IMovable: ITransformPosition
{
    Vector3 CurrentVelocity { get; }

    void SetMoveDirection(Vector3 inputDirection);
}
