using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private float _gameTime;
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private GameObject _player;

    private int _currentTime;
    private bool _isGamePlaying;

    private void Start()
    {
        _currentTime = (int)_gameTime;
        _isGamePlaying = true;
    }

    private void Update()
    {
        if (_isGamePlaying)
            TimerUpdate();
    }

    private void TimerUpdate()
    {
        _gameTime -= Time.deltaTime;

        if (_gameTime < _currentTime)
        {
            _currentTime = (int)_gameTime;
            Debug.Log($"Осталось: {_currentTime} секунд");
        }
        
        if(_gameTime <= 0)
        {
            StopGame(false);
        }
    }

    private void StopGame(bool isCoinsCountZero)
    {
        _isGamePlaying = false;
        _player.SetActive(false);
        
         if(isCoinsCountZero)
             Debug.Log("Поздравляю! Ты собрал все монетки!");
         else
             Debug.Log("Увы! Успеешь собрать в следующий раз!");
    }
    
    public void DeletCoin(Coin coin)
    {
        _coins.Remove(coin);

        if (_coins.Count == 0)
        {
            StopGame(true);
        }
    }
}
