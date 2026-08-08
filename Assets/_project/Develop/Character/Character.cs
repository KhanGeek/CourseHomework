using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravity;
    [SerializeField] private float _wallGravityMultiplier;
    
    [SerializeField] private ObstacleService _obstacleService;
    
    private IMoveInput _moveInput;
    private Rigidbody2D _rigidbody;
    
    private HorizontalMover _horizontalMover;
    private HandleGravity _gravityHandle;
    private Jumper _jumper;
    
    private Vector2 _velocity;
    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if(_rigidbody == null)
            Debug.LogError("Character needs a Rigidbody2D");
        
        _moveInput=GetComponent<IMoveInput>();
        
        if(_moveInput == null)
            Debug.LogError("Character needs a IMoveInput");

        _horizontalMover = new HorizontalMover(_moveSpeed);
        _jumper = new Jumper(_jumpVelocity, _obstacleService);
        _gravityHandle = new HandleGravity(_obstacleService, _gravity, _wallGravityMultiplier);

        _moveInput.JumpRequested += _jumper.OnJump;
    }

    private void OnDestroy()
    {
        _moveInput.JumpRequested -= _jumper.OnJump;
    }

    private void FixedUpdate()
    {
        _velocity.x = _horizontalMover.GetVelocity(_moveInput.GetHorizontalInput()).x;
        _velocity.y = _gravityHandle.Apply(_velocity.y, Time.fixedDeltaTime);
        
        if(_jumper.TryJump(out float velocityY))
            _velocity.y = velocityY;

        _rigidbody.velocity = _velocity;
    }
}
