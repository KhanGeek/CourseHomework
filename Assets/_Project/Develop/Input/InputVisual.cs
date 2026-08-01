using System;
using UnityEngine;

public class InputVisual : MonoBehaviour
{
    private const float MinDistance = 0.2f;
    
    [SerializeField] private GameObject _targetPointPrefab;
    [SerializeField] private MainCharacterController _mainCharacterController;
    
    private GameObject _currentTargetPoint;

    private void Awake()
    {
        _currentTargetPoint = Instantiate(_targetPointPrefab, transform.position, Quaternion.identity);
        _currentTargetPoint.SetActive(false);
    }

    private void Update()
    {
        Vector3 currentPosition = _mainCharacterController.GetCharacterPosition();
        Vector3 targetPosition = _mainCharacterController.GetCharacterEndPointPosition();
        
        float distance =  Vector3.Distance(currentPosition, targetPosition);

        if (distance < MinDistance)
        {
            _currentTargetPoint.SetActive(false);
        }
        else
        {
            _currentTargetPoint.transform.position = targetPosition;
            _currentTargetPoint.SetActive(true);
        }
    }
}
