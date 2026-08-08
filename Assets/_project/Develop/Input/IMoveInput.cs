using System;

public interface IMoveInput
{
    event Action JumpRequested;
    float GetHorizontalInput();
}
