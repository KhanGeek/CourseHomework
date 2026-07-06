using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CollisionController _collisionController;
    [SerializeField] private DestroyVisual _destroyVisual;
    
    private IMovementBehavior _idleMovementBehavior;
    private IMovementBehavior _reactionMovementBehavior;
    private IMovementBehavior _currentMovementBehavior;

    private void Update()
    {
        if (_collisionController.IsPlayerDetected)
            SetActiveReactionBehavior();
        else
            SetActiveIdleBehavior();
        
        _currentMovementBehavior.Step();
    }

    private void SetActiveIdleBehavior() => _currentMovementBehavior = _idleMovementBehavior;

    private void SetActiveReactionBehavior() => _currentMovementBehavior = _reactionMovementBehavior;

    public void Initialize(IMovementBehavior idleMovementBehavior, IMovementBehavior reactionMovementBehavior)
    {
        _idleMovementBehavior = idleMovementBehavior;
        _reactionMovementBehavior = reactionMovementBehavior;
    }

    public void Destroy()
    {
        _destroyVisual.ParticlesPlay();
        Destroy(gameObject);
    }
}
