using System;

public interface IUpdatable
{
    event Action<IUpdatable> Destroy;
    void Update(float deltaTime);
}
