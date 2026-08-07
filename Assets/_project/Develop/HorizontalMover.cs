using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover 
{
    private float _speed;

    public HorizontalMover(float speed) => _speed = speed;

    public Vector2 GetVelocity(float xInput) => new(xInput * _speed, 0);
}
