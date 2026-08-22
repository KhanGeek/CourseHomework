using System;
using UnityEngine;

public class EnemyController : Controller
{
    private LevelBound _levelBound;

    private Vector3 _currentTarget;

    private Timer _timer;
    private float _timeToNextTarget;

    private float _minDistanceToTarget = 1f;
    
    private Action _deathAction;

    public EnemyController(Character character, 
        LevelBound levelBound, 
        Timer timer, 
        float timeToNextTarget,
        Action deathAction):
        base(character)
    {
        _levelBound = levelBound;
        _timer = timer;
        _timeToNextTarget = timeToNextTarget;
        _deathAction = deathAction;

        SetNewTargetPosition();
    }

    public override void Update(float deltaTime)
    {
        Vector3 position = _character.transform.position;

        if (Vector3.Distance(_currentTarget, position) > _minDistanceToTarget)
            _character.SetDirection(_currentTarget - position);
        else
            _character.SetDirection(Vector3.zero);
    }

    private void SetNewTargetPosition()
    {
        _currentTarget = _levelBound.GetRandomPosition();

        _timer.Start(_timeToNextTarget, SetNewTargetPosition);
    }

    protected override void OnDeath()
    {
        _deathAction?.Invoke();
        base.OnDeath();
    }
}
