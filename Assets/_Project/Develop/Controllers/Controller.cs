using System;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class Controller : IUpdatable, IDisposable, IDestroyable
{
    public event Action<IDestroyable> Destroy;
    
    protected Character _character;

    public Controller(Character character)
    {
        _character = character;
        
        _character.Health.Death += OnDeath;
    }

    public abstract void Update(float deltaTime);

    public void Dispose()
    {
        Destroy?.Invoke(this);
        
        if (_character == null)
            return;

        _character.Health.Death -= OnDeath;
        Object.Destroy(_character.gameObject);
    }

    private void OnDeath()
    {
        Dispose();
    }
}