using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private const int ZeroTime = 0;

    private ReactiveVariable<float> _currentTime = new();
    private ReactiveVariable<float> _startTime = new();
    private bool _isPaused;

    private Coroutine _coroutine;
    private MonoBehaviour _monoBehaviour;

    public Timer(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
    }
    
    public IReadOnlyReactiveVariable<float> CurrentTime => _currentTime;
    
    public IReadOnlyReactiveVariable<float> StartTime => _startTime;

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

        _currentTime.Value = ZeroTime;
    }

    private IEnumerator TimerCoroutine(float time, Action callback)
    {
        _isPaused = false;
        _startTime.Value = _currentTime.Value = time;

        while (_currentTime.Value > ZeroTime)
        {
            yield return null;

            if (_isPaused)
                continue;

            _currentTime.Value -= Time.deltaTime;
        }

        callback?.Invoke();
        Clear();
    }
}