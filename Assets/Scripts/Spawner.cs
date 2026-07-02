using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private IdleBehaviorEnum _idleBehaviorEnum;
    [SerializeField] private ReactBehaviorEnum _reactBehaviorEnum;
    [SerializeField] private EnemyController _enemyPrefab;

    private void Start()
    {
        EnemyController enemyController=Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemyController.Initialized(SelectIdleBehavior(), SelectReactBehavior());
    }

    private IIdleBehavior SelectIdleBehavior()
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
        
        return idleBehavior;
    }

    private IReactionBehavior SelectReactBehavior()
    {
        IReactionBehavior reactionBehavior;

        switch (_reactBehaviorEnum)
        {
            case ReactBehaviorEnum.Escape:
                reactionBehavior = new ReactEscapeBehevior();
                break;
            
            case ReactBehaviorEnum.Destroy:
                reactionBehavior = new ReactDestroyBehavior();
                break;
            
            case ReactBehaviorEnum.Pursuit:
                reactionBehavior = new ReactPursuitBehavior();
                break;
            
            default:
                reactionBehavior = null;
                Debug.LogError("Invalid reaction behavior");
                break;
        }
        
        return reactionBehavior;
    }
}
