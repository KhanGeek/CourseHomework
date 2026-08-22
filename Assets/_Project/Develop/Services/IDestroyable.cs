using System;

public interface IDestroyable
{
    event Action<IDestroyable> Destroy;
}