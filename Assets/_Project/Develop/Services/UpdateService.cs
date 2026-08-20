using System.Collections.Generic;

public class UpdateService
{
    private List<IUpdatable> _updatables = new();

    public void Add(IUpdatable updatable)
    {
        _updatables.Add(updatable);
        updatable.Destroy += OnDestroy;
    }

    private void OnDestroy(IUpdatable updatable)
    {
        updatable.Destroy -= OnDestroy;
        _updatables.Remove(updatable);
    }

    public void Update(float deltaTime)
    {
        foreach (IUpdatable updatable in _updatables)
            updatable.Update(deltaTime);
    }
}
