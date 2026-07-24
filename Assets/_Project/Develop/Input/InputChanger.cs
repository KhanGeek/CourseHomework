using System;
using UnityEngine;

public class InputChanger : MonoBehaviour
{
    [SerializeField] private AIInput _AIInput;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private Character _character;

    [SerializeField] private float _idleTime;
    private float _currentTime;

    private bool _isPlayerInputActive;

    private void Start()
    {
        PlayerInputActivate();
        PlayerInputDeactivate();
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0 && _isPlayerInputActive == false) 
            _character.ChangeInputService(_AIInput);
    }

    public void PlayerInputActivate()
    {
        _character.ChangeInputService(_playerInput);
        _isPlayerInputActive = true;
    }

    public void PlayerInputDeactivate()
    {
        _currentTime = _idleTime;
        _isPlayerInputActive = false;
    }
}
