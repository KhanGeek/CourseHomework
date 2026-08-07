using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> Started; 
    public event Action<float> Changed;
    
    private const int ZeroTime = 0;

    private float _currentTime;
    private float _startTime;
    private bool _isPaused;

    private Coroutine _coroutine;
    private MonoBehaviour _monoBehaviour;

    public Timer(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
    }

    public bool TryStartNew(float time, Action callbackFinishTimer = null)
    {
        if (_coroutine != null)
        {
            Debug.LogWarning("Timer is already running!");
            return false;
        }

        _coroutine = _monoBehaviour.StartCoroutine(TimerCoroutine(time, callbackFinishTimer));
        return true;
    }

    public void Pause() => _isPaused = true;

    public void Resume() => _isPaused = false;

    public void Clear()
    {
        _monoBehaviour.StopCoroutine(_coroutine);
        _coroutine = null;
        
        Changed?.Invoke(ZeroTime);
    }

    private IEnumerator TimerCoroutine(float time, Action callback)
    {
        _isPaused = false;
        _startTime = _currentTime = time;
        Started?.Invoke(_startTime);

        while (_currentTime > ZeroTime)
        {
            //yield return new WaitWhile(() => _isPaused); //слишком большая задержка. таймер тикал раза в 2 медленней(

            yield return null;

            if (_isPaused)
                continue;

            _currentTime -= Time.deltaTime;

            Changed?.Invoke(_currentTime);
        }

        callback?.Invoke();
        Clear();
    }
}