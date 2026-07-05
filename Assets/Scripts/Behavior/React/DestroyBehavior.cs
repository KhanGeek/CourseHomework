using UnityEngine;

public class DestroyBehavior:IBehavior
{
    private EnemyController _enemyController;
    
    public DestroyBehavior(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }
    
    public Vector3 Update()
    {
        _enemyController.Destroy();
        return Vector3.zero;
    }
}