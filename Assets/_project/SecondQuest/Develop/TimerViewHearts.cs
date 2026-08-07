using System.Collections.Generic;
using UnityEngine;

public class TimerViewHearts : MonoBehaviour
{
    [SerializeField] private TimerExample _timer;
    [SerializeField] private GameObject _heartPrefab;

    private int currentHeartCount;
    [SerializeField]private List<GameObject> _hearts;
    
    private void Start()
    {
        _hearts = new List<GameObject>();
        _timer.Changed += OnChanged;
    }

    private void OnDestroy()
    {
        _timer.Changed -= OnChanged;
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
