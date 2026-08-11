using UnityEngine;
using UnityEngine.UI;

public class TimerViewSlider : MonoBehaviour
{
    private Timer _timer;
    [SerializeField] private Slider _slider;
    
    private float _startTime;

    private void OnDestroy()
    {
        _timer.CurrentTime.Changed -= OnCurrentTimeChanged;
        _timer.StartTime.Changed -= OnStartTimeChanged;
    }

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.CurrentTime.Changed += OnCurrentTimeChanged;
        _timer.StartTime.Changed += OnStartTimeChanged;
    }

    private void OnStartTimeChanged(float startTime)
    {
        _startTime = startTime;
        OnCurrentTimeChanged(_startTime);
    }

    private void OnCurrentTimeChanged(float currentTime)
    {
        if (currentTime > 0)
            _slider.value = currentTime / _startTime;
        else
            _slider.value = 0;
    }
}
