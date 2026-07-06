using UnityEngine;

public class DestroyMovementBehavior:IMovementBehavior
{
    private EnemyController _enemyController;
    
    public DestroyMovementBehavior(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }

    public void Step() => _enemyController.Destroy();
}