using System.Collections.Generic;

public class UpdateService
{
    private List<IUpdatable> _updatables = new();

    public void Add(IUpdatable updatable)
    {
        _updatables.Add(updatable);
        
        if(updatable is IDestroyable destroyable)
            destroyable.Destroy += OnDestroy;
    }

    private void OnDestroy(IDestroyable destroyable)
    {
        destroyable.Destroy -= OnDestroy;

        if (destroyable is IUpdatable updatable)
            _updatables.Remove(updatable);
    }

    public void Update(float deltaTime)
    {
        foreach (IUpdatable updatable in _updatables)
            updatable.Update(deltaTime);
    }
}
