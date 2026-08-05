using UnityEngine;
using UnityEngine.UI;

public class TimerViewSlider : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Slider _slider;

    private void Start() => _timer.TimeChanged += OnTimeChanged;

    private void OnDestroy() => _timer.TimeChanged -= OnTimeChanged;

    private void OnTimeChanged(float currentTime, float startTime)
    {
        if (startTime > 0)
            _slider.value = currentTime / startTime;
        else
            _slider.value = 0;
    }
}
