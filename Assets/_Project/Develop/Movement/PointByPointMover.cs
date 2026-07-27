using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointByPointMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenMoves;

    private Queue<Vector3> _pointsPosition;
    private Vector3 _currentPoint;

    private void Awake()
    {
        _pointsPosition = new Queue<Vector3>();
        
        foreach (Transform point in _points)
            _pointsPosition.Enqueue(point.position);

        StartCoroutine(ProcessMove());
    }

    private IEnumerator ProcessMove()
    {
        while (true)
        {
            SwitchPoint();

            Vector3 startPosition = transform.position;
            Vector3 endPosition = _currentPoint;

            float time = (endPosition - startPosition).magnitude / _speed;

            float process = 0;

            while (process < time)
            {
                process += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, process / time);
                yield return null;
            }
            
            yield return new  WaitForSeconds(_timeBetweenMoves);
        }
    }

    private void SwitchPoint()
    {
        _currentPoint = _pointsPosition.Dequeue();
        _pointsPosition.Enqueue(_currentPoint);
    }
}
