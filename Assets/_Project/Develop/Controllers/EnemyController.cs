using System;
using UnityEngine;

public class EnemyController: IUpdatable, IDisposable
{
    public event Action<IUpdatable> Destroy;

    private Character _character;
    private LevelBound _levelBound;
    
    private Vector3 _currentTarget;

    private Timer _timer;
    private float _timeToNextTarget;

    private float _minDistanceToTarget = 1f;
    
    public EnemyController(Character character, LevelBound levelBound, Timer timer, float timeToNextTarget)
    {
        _character = character;
        _levelBound = levelBound;
        _timer = timer;
        _timeToNextTarget = timeToNextTarget;

        SetNewTargetPosition();
    }

    public void Update(float deltaTime)
    {
        Vector3 position = _character.transform.position;

        if (Vector3.Distance(_currentTarget, position) > _minDistanceToTarget)
            _character.SetDirection(_currentTarget - position);
        else
            _character.SetDirection(Vector3.zero);
    }

    public void Dispose() => Destroy?.Invoke(this);

    private void SetNewTargetPosition()
    {
        _currentTarget = _levelBound.GetRandomPosition();
        
        _timer.Start(_timeToNextTarget, SetNewTargetPosition);
    }
}
