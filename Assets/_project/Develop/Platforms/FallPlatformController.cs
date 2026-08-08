using System.Collections;
using UnityEngine;

public class FallPlatformController : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate;
    [SerializeField] private float _timeToRestart;
    [SerializeField] private Transform _platformTransform;
    [SerializeField] private CollisionReserver _collisionReserver;
    
    private Coroutine _coroutine;

    private void Start() => _collisionReserver.Activate += OnActivate;

    private void OnDestroy() => _collisionReserver.Activate -= OnActivate;

    private void OnActivate()
    {
        if (_coroutine != null)
            return;

        _coroutine = StartCoroutine(OnOffCoroutine());
    }

    private IEnumerator OnOffCoroutine()
    {
        yield return new WaitForSeconds(_timeToDeactivate);
        
        _platformTransform.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(_timeToRestart);
        
        _platformTransform.gameObject.SetActive(true);
    }
}
