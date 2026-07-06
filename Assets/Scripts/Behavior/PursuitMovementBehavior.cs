using System.Collections.Generic;
using UnityEngine;

public class PursuitMovementBehavior : IMovementBehavior
{
    private Transform _characterTransform;
    private Transform _enemyTransform;
    
    private List<ITransformable> _transformables;

    public PursuitMovementBehavior(Transform characterTransform, Transform enemyTransform, List<ITransformable> transformables)
    {
        _characterTransform = characterTransform;
        _enemyTransform = enemyTransform;
        _transformables = transformables;
    }

    public Vector3 Update()
    {
        Vector3 direction = _enemyTransform.position - _characterTransform.position;
        return direction;
    }

    public void Step()
    {
        Vector3 direction = _enemyTransform.position - _characterTransform.position;

        foreach (ITransformable transformable in _transformables) 
            transformable.ApplyMovement(direction);
    }
}