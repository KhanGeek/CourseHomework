using UnityEngine;

public class Platform: MonoBehaviour
{
    [SerializeField] private CollisionReserver _collisionReserver;
    [SerializeField] private Transform _platformEngineTransform;
    [SerializeField]private float _timeToDeactivate;
    [SerializeField]private float _timeToRestart;

    private IReaction _platformReaction;

    private void Start()
    {
        _platformReaction =
            new FallPlatformController(_timeToDeactivate, _timeToRestart, _platformEngineTransform, this);

        _collisionReserver.Activated += _platformReaction.OnActivated;
    }

    private void OnDestroy()
    {
        _collisionReserver.Activated -= _platformReaction.OnActivated;
    }
}
