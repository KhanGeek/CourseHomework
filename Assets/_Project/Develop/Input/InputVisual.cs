using UnityEngine;

public class InputVisual : MonoBehaviour
{
    [SerializeField] private GameObject _targetPointPrefab;
    
    private GameObject _currentTargetPoint;

    public void SetNextTargetPoint(Vector3 targetPoint)
    {
        DestroyTargetPoint();
        
        _currentTargetPoint = Instantiate(_targetPointPrefab, targetPoint, Quaternion.identity);
    }

    public void DestroyTargetPoint() => Destroy(_currentTargetPoint);
}
