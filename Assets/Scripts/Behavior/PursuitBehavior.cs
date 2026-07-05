using UnityEngine;

public class PursuitBehavior : IBehavior
{
    private Transform _characterTransform;
    private Transform _enemyTransform;

    public PursuitBehavior(Transform characterTransform, Transform enemyTransform)
    {
        _characterTransform = characterTransform;
        _enemyTransform = enemyTransform;
    }

    public Vector3 Update()
    {
        Vector3 direction = _enemyTransform.position - _characterTransform.position;
        return direction;
    }
}