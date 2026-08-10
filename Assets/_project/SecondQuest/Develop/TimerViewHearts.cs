using System.Collections.Generic;
using UnityEngine;

public class TimerViewHearts : MonoBehaviour
{
    private Timer _timer;
    [SerializeField] private GameObject _heartPrefab;

    private int currentHeartCount;
    [SerializeField]private List<GameObject> _hearts;

    private void OnDestroy()
    {
        _timer.Changed -= OnChanged;
    }

    public void Initialize(Timer timer)
    {
        _hearts = new List<GameObject>();
        
        _timer = timer;
        _timer.Changed += OnChanged;
    }

    private void OnChanged(float currentTime)
    {
        currentHeartCount = Mathf.CeilToInt(currentTime);

        if (currentHeartCount > _hearts.Count)
            AddHeart(currentHeartCount - _hearts.Count);

        if (currentHeartCount < _hearts.Count)
            RemoveHeart(_hearts.Count - currentHeartCount);
    }

    private void AddHeart(int count)
    {
        for(int i=0; i<count; i++)
            _hearts.Add(Instantiate(_heartPrefab, transform));
    }
    
    private void RemoveHeart(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Destroy(_hearts[0]);
            _hearts.Remove(_hearts[0]);
        }
    }
}
