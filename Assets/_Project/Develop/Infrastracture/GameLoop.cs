using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop
{
    private GameConfig _gameConfig;
    private ControllersFactory _controllersFactory;  
    private UpdateService _updateService;
    private Timer _timer;
    private MonoBehaviour _coroutineStarter;

    private EnemySpawner _enemySpawner;
    private PlayerController _playerController;
    private PlayerFactory _playerFactory;
    
    private int _playerKillCount;
    
    private ObjectSearchService _searchService;
    private ResourcesLoadService _resourcesLoadService;
    
    public GameLoop(UpdateService updateService, 
        ControllersFactory controllersFactory, 
        Timer timer, 
        MonoBehaviour coroutineStarter, 
        ObjectSearchService searchService, 
        ResourcesLoadService resourcesLoadService, 
        PlayerFactory playerFactory)
    {
        _updateService = updateService;
        _controllersFactory = controllersFactory;
        _timer = timer;
        _coroutineStarter = coroutineStarter;
        _searchService = searchService;
        _resourcesLoadService = resourcesLoadService;
        _playerFactory = playerFactory;

        _gameConfig = _resourcesLoadService.LoadGameConfig();
    }

    public bool IsGamePlaying { get; private set; }

    public IEnumerator Preparation()
    {
        yield return SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        
        yield return CreatePlayer();

        _enemySpawner = new EnemySpawner(
            _gameConfig.TimeToEnemySpawn, 
            _controllersFactory, 
            _updateService, 
            _searchService.FindLevelBound(),
            _timer,
            _coroutineStarter,
            AddKillCount,
            _searchService);
        
        Start();
    }

    private void Win()
    {
        Stop();
        Debug.Log("Вы выйграли!");
    }

    private void Defeat()
    {
        Stop();
        Debug.Log("Вы проиграли!");
    }
    
    private void Stop()
    {
        IsGamePlaying = false;
        _playerController.Dispose();
        _enemySpawner.Dispose();
    }

    private void Start()
    {
        GameRules gameRules = new GameRules();

        _coroutineStarter.StartCoroutine(
            gameRules.GameRuleCoroutine(
                GetWinGameRule(_gameConfig.VictoryCondition), Win));
        
        _coroutineStarter.StartCoroutine(
            gameRules.GameRuleCoroutine(
                GetDefeatGameRule(_gameConfig.DefeatCondition), Defeat));
        
        IsGamePlaying = true;
    }

    private IEnumerator CreatePlayer()
    {
        _playerController = _playerFactory.CreatePlayer();

        yield return null;
    }

    private void AddKillCount() => _playerKillCount++;

    private Func<bool> GetWinGameRule(VictoryCondition condition)
    {
        Func<bool> winGameRule;
        
        switch (condition)
        {
            case VictoryCondition.KillEnemies:
                winGameRule = () => _playerKillCount >= _gameConfig.VictoryValue;
                break;

            case VictoryCondition.SurviveForSeconds:
                winGameRule = () => _playerController.CurrentGameTime >= _gameConfig.VictoryValue;
                break;

            default:
                throw new ArgumentOutOfRangeException("VictoryCondition");
        }

        return winGameRule;
    }
    
    private Func<bool> GetDefeatGameRule(DefeatCondition condition)
    {
        Func<bool>  defeatGameRule;
        
        switch (condition)
        {
            case DefeatCondition.PlayerDied:
                defeatGameRule = () => _playerController.IsDead;
                break;

            case DefeatCondition.MoreThanEnemies:
                defeatGameRule = () => _enemySpawner.Count >= _gameConfig.DefeatValue;
                break;

            default:
                throw new ArgumentOutOfRangeException("DefeatCondition");
        }

        return defeatGameRule;
    }
}
