using System;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private TimerViewHearts _timerViewHearts;
    [SerializeField] private TimerViewSlider _timerViewSlider;
    
    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(this);
        
        _timerViewHearts.Initialize(_timer);
        _timerViewSlider.Initialize(_timer);
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
