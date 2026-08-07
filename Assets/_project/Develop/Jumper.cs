using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper
{
    private float _jumpForce;
    private Character _character;
    private Vector2 _velocity;

    public Jumper(float jumpForce, Character character)
    {
        _jumpForce = jumpForce;
        _character = character;
    }

    public void OnJump()
    {
        if(_character.IsGrounded || _character.IsWallTouches)
            _velocity=new Vector2(0, _jumpForce);
    }

    public Vector2 GetVelocity()
    {
        Vector2 newVelocity = _velocity;
        _velocity = Vector2.zero;
        return newVelocity;
    }
}
