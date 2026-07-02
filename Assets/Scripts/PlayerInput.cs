using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputBehavior
{
    private void Update()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }
}
