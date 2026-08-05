using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<float, float> TimeChanged;
    
    private const int ZeroTime = 0;

    private float _currentTime;
    private float _startTime;
    private bool _isPaused;

    private Coroutine _coroutine;

    public bool TryStartNew(float time, Action callbackFinishTimer = null)
    {
        if (_coroutine != null)
        {
            Debug.LogWarning("Timer is already running!");
            return false;
        }

        _coroutine = StartCoroutine(TimerCoroutine(time, callbackFinishTimer));
        return true;
    }

    public void Pause() => _isPaused = true;

    public void Resume() => _isPaused = false;

    public void Clear()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
        
        TimeChanged?.Invoke(ZeroTime, ZeroTime);
    }

    private IEnumerator TimerCoroutine(float time, Action callback)
    {
        _isPaused = false;
        _startTime = _currentTime = time;
        TimeChanged?.Invoke(_currentTime, _startTime);

        while (_currentTime > ZeroTime)
        {
            //yield return new WaitWhile(() => _isPaused); //слишком большая задержка. таймер тикал раза в 2 медленней(

            yield return null;

            if (_isPaused)
                continue;

            _currentTime -= Time.deltaTime;

            TimeChanged?.Invoke(_currentTime, _startTime);
        }

        callback?.Invoke();
        Clear();
    }
}