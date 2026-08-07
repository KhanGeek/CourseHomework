using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _curve;

    private Queue<Vector3> _targetPositions;
    private Vector3 _currentTargetPosition;

    private void Awake()
    {
        _targetPositions = new Queue<Vector3>();
        _targetPositions.Enqueue(_firstPoint.position);
        _targetPositions.Enqueue(_secondPoint.position);
        
        NextTargetPosition();
    }

    private void Start()
    {
        StartCoroutine(MoveCorutine());
    }

    private void NextTargetPosition()
    {
        _currentTargetPosition = _targetPositions.Dequeue();
        _targetPositions.Enqueue(_currentTargetPosition);
    }

    private IEnumerator MoveCorutine()
    {
        while (true)
        {
            float time = Vector3.Distance(_enemy.position, _currentTargetPosition) / _speed;
            float duration = 0;

            while (duration<time)
            {
                duration += Time.deltaTime;
                _enemy.position=Vector3.Lerp(_enemy.position, _currentTargetPosition, _curve.Evaluate(duration/time));
                yield return null;
            }
            
            NextTargetPosition();
        }
    }
}
