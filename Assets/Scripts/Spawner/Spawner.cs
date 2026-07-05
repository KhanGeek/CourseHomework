using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] List<Transform> _waypointsList;
    
    [SerializeField] private Collider _groundCollider;
    [SerializeField] private Transform _playerTransform;

    private void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
            SpawnEnemy(spawnPoint);
    }

    private Queue<Vector3> GetWaypointsQueue()
    {
        Queue<Vector3> queue = new Queue<Vector3>();
        
        foreach (var waypoints in _waypointsList)
            queue.Enqueue(waypoints.position);
        
        return queue;
    }

    private void SpawnEnemy(SpawnPoint spawnPoint)
    {
        EnemyController enemyController=Instantiate(_enemyPrefab, spawnPoint.GetTransform().position, Quaternion.identity);

        enemyController.Initialize(SelectBehavior(spawnPoint.GetIdleBehavior(), enemyController),
            SelectBehavior(spawnPoint.GetReactionBehavior(), enemyController));
    }

    private IBehavior SelectBehavior(Behaviors selectedBehavior, EnemyController enemyController)
    {
        IBehavior behavior;

        switch (selectedBehavior)
        {
            case Behaviors.Stationary:
                behavior = new StationaryBehavior();
                break;
            
            case Behaviors.WaypointPatrol:
                behavior = new WaypointPatrolBehavior(GetWaypointsQueue(), enemyController.transform);
                break;
            
            case Behaviors.FreePatrol:
                behavior = new FreePatrolBehavior(enemyController.transform, _groundCollider.bounds);
                break;
            
            case Behaviors.Escape:
                behavior = new EscapeBehevior(enemyController.transform, _playerTransform);
                break;
            
            case Behaviors.Destroy:
                behavior = new DestroyBehavior(enemyController);
                break;
            
            case Behaviors.Pursuit:
                behavior = new PursuitBehavior(enemyController.transform, _playerTransform);
                break;
            
            default:
                behavior = null;
                Debug.LogError("Invalid behavior");
                break;
        }
        
        return behavior;
    }
}
