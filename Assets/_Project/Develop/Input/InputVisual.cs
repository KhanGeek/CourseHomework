using UnityEngine;

public class InputVisual : MonoBehaviour
{
    [SerializeField] private GameObject _targetPointPrefab;
    [SerializeField] private MainCharacterController _mainCharacterController;
    
    private GameObject _currentTargetPoint;

    private void Update()
    {
        if (_mainCharacterController.TryGetMoveTargetPosition(out Vector3 position))
        {
            if (_currentTargetPoint == null)
            {
                _currentTargetPoint = Instantiate(_targetPointPrefab, position, Quaternion.identity);
            }
            else
            {
                if (_currentTargetPoint.transform.position != position)
                {
                    _currentTargetPoint.transform.position = position;
                }
            }
        }
        else
        {
            Destroy(_currentTargetPoint);
            _currentTargetPoint = null;
        }
    }
}
