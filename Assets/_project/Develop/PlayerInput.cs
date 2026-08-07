using System;
using UnityEngine;

public class PlayerInput :MonoBehaviour, IMoveInput
{
    public event Action JumpRequested;
    
    private const string HorizontalAxisKey = "Horizontal";

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            JumpRequested?.Invoke();
    }

    public float GetHorizontalInput() => Input.GetAxisRaw(HorizontalAxisKey);
}