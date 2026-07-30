using System;
using Unity.VisualScripting;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    [SerializeField] private float _minChangePointTime;
    [SerializeField] private float _maxChangePointTime;
    [SerializeField] private GameObject _floorParrentGameObject;
    
    [SerializeField] private FirstAidKit _firstAidKitPrefab;
    [SerializeField] private float _firstAidKitSpawnRadius;
    [SerializeField] private float _firstAidKitTimeToSpawn;
    
    [SerializeField] private InputVisual _inputVisual;
    
    [SerializeField] private Character _character;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private float _timeToSwitchControllerUponInactivity;
    
    private PlayerCharacterMovementController _playerCharacterMovementController;
    private AICharacterMovementController _aiCharacterMovementController;
    
    private ICharacterMovomentController _currentCharacterMovomentController;

    private void Awake()
    {
        _playerCharacterMovementController = new PlayerCharacterMovementController(_character, _playerInput);
        
        _aiCharacterMovementController = new AICharacterMovementController(
            _character,
            _minChangePointTime,
            _maxChangePointTime,
            _floorParrentGameObject);

        _currentCharacterMovomentController = _playerCharacterMovementController;
    }

    private void Update()
    {
        if (EnoughPlayerInactivityTime())
            _currentCharacterMovomentController = _aiCharacterMovementController;
        else
            _currentCharacterMovomentController = _playerCharacterMovementController;

        _currentCharacterMovomentController.Update();
    }

    public bool TryGetMoveTargetPosition(out Vector3 position)
    {
        if (_currentCharacterMovomentController.IsMove)
        {
            position = _character.GetEndPointPosition();
            return true;
        }

        position = Vector3.zero;
        return false;
    }

    private bool EnoughPlayerInactivityTime()
    {
        if(_playerInput.GetTimeTheLastClicked > _timeToSwitchControllerUponInactivity)
            return true;
        return false;
    }
}
