using UnityEngine;

public class EnemyController : InputBehavior
{
    private IIdleBehavior _idleBehavior;
    private IReactionBehavior _reactionBehavior;
    private bool _isReacting;

    private void Update()
    {
        if (_isReacting == false)
        {
            _idleBehavior.Update(transform, ref _direction);
        }
    }
    
    public void Initialized(IIdleBehavior idleBehavior, IReactionBehavior reactionBehavior)
    {
        _idleBehavior = idleBehavior;
        _reactionBehavior = reactionBehavior;
    }

    public void Destroy() => Destroy(gameObject);

    public void ReactActive(Transform target)
    {
        _isReacting = true;
        _reactionBehavior.Update(transform, target, ref _direction);
    }

    public void ReactDisabled() => _isReacting = false;
}
