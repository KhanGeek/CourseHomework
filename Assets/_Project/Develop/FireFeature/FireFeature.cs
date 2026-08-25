using UnityEngine;
using Object = UnityEngine.Object;

public class FireFeature : IFeature
{
    private FireBall _fireBallPrefab;

    public FireFeature(FireBall fireBallPrefab)
    {
        _fireBallPrefab = fireBallPrefab;
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
