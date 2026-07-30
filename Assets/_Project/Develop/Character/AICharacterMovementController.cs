using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacterMovementController : ICharacterMovomentController
{
    private Character _character;

    private float _minChangePointTime;
    private float _maxChangePointTime;
    private GameObject _floorParrentGameObject;

    private Bounds _floorBounds;

    private float _currentTime;
    private bool _isMovement;

    public AICharacterMovementController(
        Character character,
        float minChangePointTime,
        float maxChangePointTime,
        GameObject floorParrentGameObject)
    {
        _character = character;
        _minChangePointTime = minChangePointTime;
        _maxChangePointTime = maxChangePointTime;
        _floorParrentGameObject = floorParrentGameObject;

        GetFloorChildrenBound();
    }
    
    public bool IsMove => _isMovement;

    public void Update()
    {
        _currentTime -= Time.deltaTime;
        
        if (HasAppearedNextTargetPoint())
        {
            SetNextTargetPoint();
        }

        if (_character.EnoughCornersCountInPath() == false && _isMovement)
        {
            _isMovement = false;
        }
    }

    private bool HasAppearedNextTargetPoint() => _currentTime <= 0;

    private bool TryGetNextTargetPoint(out Vector3 targetPoint)
    {
        targetPoint = new Vector3(Random.Range(_floorBounds.min.x, _floorBounds.max.x),
            0, Random.Range(_floorBounds.min.z, _floorBounds.max.z));

        SetNewTimer();
        return true;
    }

    private void SetNextTargetPoint()
    {
        if (TryGetNextTargetPoint(out Vector3 targetPoint))
        {
            _character.SetDestination(targetPoint);
            _isMovement = true;
        }
    }

    private void SetNewTimer() => _currentTime = Random.Range(_minChangePointTime, _maxChangePointTime);

    private void GetFloorChildrenBound()
    {
        Renderer[] renderers = _floorParrentGameObject.transform.GetComponentsInChildren<Renderer>();

        _floorBounds = renderers[0].bounds;

        for (int i = 1; i < renderers.Length; i++)
            _floorBounds.Encapsulate(renderers[i].bounds);
    }
}