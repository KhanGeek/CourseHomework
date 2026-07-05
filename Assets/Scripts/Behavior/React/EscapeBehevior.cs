using UnityEngine;

public class EscapeBehevior : IBehavior
{
    private Transform _characterTransform;
    private Transform _enemyTransform;

    public EscapeBehevior(Transform characterTransform, Transform enemyTransform)
    {
        _characterTransform = characterTransform;
        _enemyTransform = enemyTransform;
    }

    public Vector3 Update()
    {
        Vector3 direction = _characterTransform.position - _enemyTransform.position;
        return direction;
    }
}
