using UnityEngine;
using UnityEngine.UI;

public class TimerViewSlider : MonoBehaviour
{
    private Timer _timer;
    [SerializeField] private Slider _slider;
    
    private float _startTime;

    private void OnDestroy()
    {
        _timer.Changed -= OnTimeChanged;
        _timer.Started -= OnStarted;
    }

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.Changed += OnTimeChanged;
        _timer.Started += OnStarted;
    }

    private void OnStarted(float startTime)
    {
        _startTime = startTime;
        OnTimeChanged(_startTime);
    }

    private void OnTimeChanged(float currentTime)
    {
        if (currentTime > 0)
            _slider.value = currentTime / _startTime;
        else
            _slider.value = 0;
    }
}
