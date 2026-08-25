using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner: IDisposable
{
    private YieldInstruction _timeToSpawn;
    private List<Vector3> _spawnPoints;
    private ControllersFactory _controllersFactory;
    private UpdateService _updateService;
    private LevelBound _levelBound;
    private Timer _timer;
    private MonoBehaviour _coroutineStarter;
    private Action _destroyAction;
    private ObjectSearchService _searchService;
    
    private Coroutine _spawnCoroutine;
    private List<EnemyController> _enemyControllers = new();

    public EnemySpawner(float timeToSpawn,
        ControllersFactory controllersFactory,
        UpdateService updateService,
        LevelBound levelBound,
        Timer timer,
        MonoBehaviour coroutineStarter, 
        Action destroyAction, 
        ObjectSearchService searchService)
    {
        _timeToSpawn = new WaitForSeconds(timeToSpawn);
        _controllersFactory = controllersFactory;
        _updateService = updateService;
        _levelBound = levelBound;
        _timer = timer;
        _coroutineStarter = coroutineStarter;
        _destroyAction = destroyAction;
        _searchService = searchService;


        _spawnPoints = _searchService.FindSpawnPoints();

        _spawnCoroutine = _coroutineStarter.StartCoroutine(EnemySpawnCoroutine());
    }

    public int Count => _enemyControllers.Count;

    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            yield return _timeToSpawn;

            EnemyController enemyController = _controllersFactory.CreateEnemyController(
                GetRandomSpawnPoint(), 
                _levelBound, 
                _timer, 
                _destroyAction);
            
            _enemyControllers.Add(enemyController);
            enemyController.Destroy += OnDestroy;
            
            _updateService.Add(enemyController);
        }
    }

    private void OnDestroy(IDestroyable destroyable)
    {
        destroyable.Destroy -= OnDestroy;

        if (destroyable is EnemyController enemyController)
            _enemyControllers.Remove(enemyController);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        if (_spawnPoints.Count == 0)
            throw new InvalidOperationException("Spawn points list is empty");
        
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    public void Dispose()
    {
        if (_spawnCoroutine != null)
            _coroutineStarter.StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = null;

        foreach (EnemyController enemyController in _enemyControllers)
        {
            enemyController.Destroy -= OnDestroy;
            enemyController.Dispose();
        }

        _enemyControllers.Clear();
    }
}
