using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InputBehavior
{
    [SerializeField] private CollisionController _collisionController;
    [SerializeField] private DestroyVisual _destroyVisual;
    
    private IBehavior _idleBehavior;
    private IBehavior _reactionBehavior;
    private IBehavior _currentBehavior;

    private void Update()
    {
        if (_collisionController.IsPlayerDetected)
            SetActiveReactionBehavior();
        else
            SetActiveIdleBehavior();
        
        Direction = _currentBehavior.Update();
    }

    private void SetActiveIdleBehavior() => _currentBehavior = _idleBehavior;

    private void SetActiveReactionBehavior() => _currentBehavior = _reactionBehavior;

    public void Initialize(IBehavior idleBehavior, IBehavior reactionBehavior)
    {
        _idleBehavior = idleBehavior;
        _reactionBehavior = reactionBehavior;
    }

    public void Destroy()
    {
        _destroyVisual.ParticlesPlay();
        Destroy(gameObject);
    }
}
