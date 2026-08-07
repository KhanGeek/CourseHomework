using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravity;
    
    [SerializeField] private ObstacleChecker _groundChecker;
    [SerializeField] private ObstacleChecker _leftWallChecker;
    [SerializeField] private ObstacleChecker _rightWallChecker;
    
    private IMoveInput _moveInput;
    private Rigidbody2D _rigidbody;
    
    private HorizontalMover _horizontalMover;
    private Jumper _jumper;
    
    private Vector2 _velocity;

    private bool _isDead;
    
    public bool IsDead => _isDead;

    public bool IsGrounded => _groundChecker.IsTouches;
    
    public bool IsWallTouches => _leftWallChecker.IsTouches || _rightWallChecker.IsTouches;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if(_rigidbody == null)
            Debug.LogError("Character needs a Rigidbody2D");
        
        _moveInput=GetComponent<IMoveInput>();
        
        if(_moveInput == null)
            Debug.LogError("Character needs a IMoveInput");

        _horizontalMover = new HorizontalMover(_moveSpeed);
        _jumper = new Jumper(_jumpVelocity, this);

        _moveInput.JumpRequested += _jumper.OnJump;
    }

    private void OnDestroy()
    {
        _moveInput.JumpRequested -= _jumper.OnJump;
    }

    private void Update()
    {
        _velocity.x = _horizontalMover.GetVelocity(_moveInput.GetHorizontalInput()).x;
        _velocity.y += _jumper.GetVelocity().y;
        
        HandleGravity();
        
        _rigidbody.velocity = _velocity;
    }

    public void Die()
    {
        _isDead = true;
        gameObject.SetActive(false);
        Debug.Log("Character is dead");
    }

    private void HandleGravity()
    {
        if (IsGrounded && _velocity.y <= 0)
            _velocity.y = 0;
        else if (IsWallTouches && _velocity.y <= 0)
            _velocity.y -= _gravity/5 * Time.deltaTime;
        else _velocity.y -= _gravity * Time.deltaTime;
    }
}
