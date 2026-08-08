using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper
{
    private ObstacleService _obstacleService;
    private float _jumpForce;
    private bool _isJumping;

    public Jumper(float jumpForce, ObstacleService obstacleService)
    {
        _jumpForce = jumpForce;
        _obstacleService = obstacleService;
    }

    public void OnJump() => _isJumping = true;

    public bool TryJump(out float velocityY)
    {
        velocityY = 0f;

        if (_isJumping == false)
            return false;

        _isJumping = false;
        
        if(_obstacleService.IsGrounded==false && _obstacleService.IsTouchingWalls==false)
            return  false;
        
        velocityY = _jumpForce;
        return true;
    }
}
