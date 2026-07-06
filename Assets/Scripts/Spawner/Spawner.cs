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

    private List<ITransformable> GetTransformables(EnemyController enemyController)
    {
        List<ITransformable> transformables = new List<ITransformable>();

        ITransformable mover = enemyController.GetComponent<Mover>();

        if (mover != null)
            transformables.Add(mover);

        ITransformable rotator = enemyController.GetComponent<Rotator>();

        if (rotator != null)
            transformables.Add(rotator);

        return transformables;
    }

    private void SpawnEnemy(SpawnPoint spawnPoint)
    {
        EnemyController enemyController=Instantiate(_enemyPrefab, spawnPoint.GetTransform().position, Quaternion.identity);

        enemyController.Initialize(SelectBehavior(spawnPoint.GetIdleBehavior(), enemyController),
            SelectBehavior(spawnPoint.GetReactionBehavior(), enemyController));
    }

    private IMovementBehavior SelectBehavior(Behaviors selectedBehavior, EnemyController enemyController)
    {
        IMovementBehavior movementBehavior;

        switch (selectedBehavior)
        {
            case Behaviors.Stationary:
                movementBehavior = new StationaryMovementBehavior();
                break;

            case Behaviors.WaypointPatrol:
                movementBehavior = new WaypointPatrolMovementBehavior(GetWaypointsQueue(), enemyController.transform,
                    GetTransformables(enemyController));
                break;

            case Behaviors.FreePatrol:
                movementBehavior = new FreePatrolMovementBehavior(enemyController.transform, _groundCollider.bounds,
                    GetTransformables(enemyController));
                break;

            case Behaviors.Escape:
                movementBehavior = new EscapeBehevior(enemyController.transform, _playerTransform, GetTransformables(enemyController));
                break;

            case Behaviors.Destroy:
                movementBehavior = new DestroyMovementBehavior(enemyController);
                break;

            case Behaviors.Pursuit:
                movementBehavior =
                    new PursuitMovementBehavior(enemyController.transform, _playerTransform, GetTransformables(enemyController));
                break;

            default:
                movementBehavior = null;
                Debug.LogError("Invalid behavior");
                break;
        }

        return movementBehavior;
    }
}