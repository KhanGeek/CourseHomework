using Unity.VisualScripting;
using UnityEngine;

public class FreePatrolBehavior : IBehavior
{
    private Vector3 _currentPoint;
    private Bounds _groundBounds;
    private Transform _characterTransform;

    public FreePatrolBehavior(Transform characterTransform, Bounds groundBounds)
    {
        _characterTransform = characterTransform;
        _groundBounds = groundBounds;
    }

    private void SetNextPoint()
    {
        _currentPoint = new Vector3(Random.Range(_groundBounds.min.x, _groundBounds.max.x),
            0, Random.Range(_groundBounds.min.z, _groundBounds.max.z));
    }

    public Vector3 Update()
    {
        if ((_currentPoint - _characterTransform.position).magnitude <= Constants.MinDistanceBetweenPoints)
            SetNextPoint();
        
        Vector3 direction = _currentPoint - _characterTransform.position;
        
        return direction;
    }
}
