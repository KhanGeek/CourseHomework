using System.Collections;
using UnityEngine;

public class FallPlatformController : IReaction
{
    private float _timeToDeactivate;
    private float _timeToRestart;
    private Transform _platformEngineTransform;

    private MonoBehaviour _coroutineStarter;
    private Coroutine _coroutine;

    public FallPlatformController(float timeToDeactivate, 
        float timeToRestart, 
        Transform platformEngineTransform, 
        MonoBehaviour coroutineStarter)
    {
        _timeToDeactivate = timeToDeactivate;
        _timeToRestart = timeToRestart;
        _platformEngineTransform = platformEngineTransform;
        _coroutineStarter = coroutineStarter;
    }

    public void OnActivated()
    {
        if (_coroutine != null)
            return;

        _coroutine = _coroutineStarter.StartCoroutine(OnOffCoroutine());
    }

    private IEnumerator OnOffCoroutine()
    {
        yield return new WaitForSeconds(_timeToDeactivate);
        
        _platformEngineTransform.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(_timeToRestart);
        
        _platformEngineTransform.gameObject.SetActive(true);
        _coroutine = null;
    }
}
