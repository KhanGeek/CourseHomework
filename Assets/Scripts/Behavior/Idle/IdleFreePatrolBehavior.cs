using UnityEngine;

public class IdleFreePatrolBehavior : IIdleBehavior
{
    private Vector3 _currentPoint;

    private void SetNextPoint() =>
        _currentPoint = new Vector3(Random.Range(-Constants.MinPositionRange, Constants.MaxPositionRange),
            0, Random.Range(-Constants.MinPositionRange, Constants.MaxPositionRange));

    public void Update(Transform transform, ref Vector3 direction)
    {
        if ((_currentPoint - transform.position).magnitude <= Constants.MinDistance)
            SetNextPoint();
        
        direction = _currentPoint - transform.position;
    }
}
