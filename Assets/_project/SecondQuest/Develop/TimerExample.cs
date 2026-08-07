using System;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    public event Action<float> Started
    {
        add => _timer.Started += value;
        remove => _timer.Started -= value;
    }
    public event Action<float> Changed
    {
        add => _timer.Changed += value;
        remove => _timer.Changed -= value;
    }
    
    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _timer.TryStartNew(10);
        
        if (Input.GetKeyDown(KeyCode.P))
            _timer.Pause();
        
        if (Input.GetKeyDown(KeyCode.R))
            _timer.Resume();
        
        if (Input.GetKeyDown(KeyCode.C))
            _timer.Clear();
    }
}
