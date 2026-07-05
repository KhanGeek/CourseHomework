using UnityEngine;

public abstract class InputBehavior : MonoBehaviour
{
    protected Vector3 Direction;

    public bool IsMoving(out Vector3 direction)
    {
        if (Direction.magnitude > Constants.InputDeadZone)
        {
            direction = Direction;
            return true;
        }
        
        direction = Vector3.zero;
        return false;
    }
}
