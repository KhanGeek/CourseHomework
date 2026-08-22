using UnityEngine;
using Object = UnityEngine.Object;

public class FireFeature : IFeature
{
    private FireBall _fireBallPrefab;

    public FireFeature()
    {
        _fireBallPrefab = Resources.Load<FireBall>("Prefabs/FireBall");
    }

    public void Activate(Transform spawnPoint)
    {
        FireBall fireBall = Object.Instantiate(
            _fireBallPrefab,
            spawnPoint.position + spawnPoint.forward,
            spawnPoint.rotation);
        
        fireBall.Fire();
    }
}
