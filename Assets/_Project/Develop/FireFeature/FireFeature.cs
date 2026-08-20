using UnityEngine;
using Object = UnityEngine.Object;

public class FireFeature : IFeature
{
    private FireBall _fireBallPrefab;
    private Transform _spawnPoint;

    public FireFeature(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
        
        _fireBallPrefab = Resources.Load<FireBall>("Prefabs/FireBall");
    }

    public void Activate()
    {
        FireBall fireBall = Object.Instantiate(
            _fireBallPrefab,
            _spawnPoint.position + _spawnPoint.forward,
            _spawnPoint.rotation);
        
        fireBall.Fire();
    }
}
