using UnityEngine;

public abstract class InputBehavior : MonoBehaviour
{
    protected Vector3 _direction;

    public bool IsMoving(out Vector3 direction)
    {
        if (_direction.magnitude > Constants.DeadZone)
        {
            direction = _direction;
            return true;
        }
        
        direction = Vector3.zero;
        return false;
    }
}
