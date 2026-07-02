using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private IdleBehaviorEnum _idleBehaviorEnum;
    [SerializeField] private ReactBehaviorEnum _reactBehaviorEnum;
    [SerializeField] private EnemyController _enemyPrefab;

    private void Start()
    {
        IIdleBehavior idleBehavior;

        switch (_idleBehaviorEnum)
        {
            case IdleBehaviorEnum.Stationary:
                idleBehavior = new IdleStationaryBehavior();
                break;
            
            case IdleBehaviorEnum.WaypointPatrol:
                idleBehavior = new IdleWaypointPatrolBehavior();
                break;
            
            case IdleBehaviorEnum.FreePatrol:
                idleBehavior = new IdleFreePatrolBehavior();
                break;
            
            default:
                idleBehavior = null;
                Debug.LogError("Invalid idle behavior");
                break;
        }
        
        EnemyController enemyController=Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemyController.Initialized(idleBehavior);
    }
}
