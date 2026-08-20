using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private MonoBehaviour _coroutineStarter;
    
    public Timer(MonoBehaviour coroutineStarter) => _coroutineStarter = coroutineStarter;

    public void Start(float time, Action callback) => _coroutineStarter.StartCoroutine(TimerCoroutine(time, callback));

    private IEnumerator TimerCoroutine(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        
        callback?.Invoke();
    }
}
