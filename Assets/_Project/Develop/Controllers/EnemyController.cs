using System;

public class EnemyController: IUpdatable, IDisposable
{
    public event Action<IUpdatable> Destroy;

    private Character _character;
    

    public EnemyController(Character character)
    {
        _character = character;
    }

    public void Update(float deltaTime)
    {
        
    }

    public void Dispose()
    {
        Destroy?.Invoke(this);
    }
}
