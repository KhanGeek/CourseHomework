using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FreePatrolMovementBehavior : IMovementBehavior
{
    private Vector3 _currentPoint;
    private Bounds _groundBounds;
    private Transform _characterTransform;
    
    private List<ITransformable> _transformables;

    public FreePatrolMovementBehavior(Transform characterTransform, Bounds groundBounds, List<ITransformable> transformables)
    {
        _characterTransform = characterTransform;
        _groundBounds = groundBounds;
        _transformables = transformables;
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

    public void Step()
    {
        if ((_currentPoint - _characterTransform.position).magnitude <= Constants.MinDistanceBetweenPoints)
            SetNextPoint();
        
        Vector3 direction = _currentPoint - _characterTransform.position;

        foreach (ITransformable transformable in _transformables) 
            transformable.ApplyMovement(direction);
    }
}
