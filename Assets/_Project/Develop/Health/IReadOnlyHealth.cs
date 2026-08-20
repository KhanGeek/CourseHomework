using System;

public interface IReadOnlyHealth
{
    event Action<float> ChangeHealth;
    event Action Death;
    float MaxHealth { get; }
}
