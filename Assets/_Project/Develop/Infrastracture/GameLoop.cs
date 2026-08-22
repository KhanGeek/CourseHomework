using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class GameLoop
{
    private GameConfig _gameConfig;
    private ControllersFactory _controllersFactory;    
    private CharacterFactory _characterFactory;
    private UpdateService _updateService;
    private Timer _timer;
    private MonoBehaviour _coroutineStarter;

    private EnemySpawner _enemySpawner;
    private PlayerController _playerController;
    
    private int _playerKillCount;
    
    public GameLoop(UpdateService updateService, 
        ControllersFactory controllersFactory, 
        Timer timer, 
        CharacterFactory characterFactory, 
        MonoBehaviour coroutineStarter)
    {
        _updateService = updateService;
        _controllersFactory = controllersFactory;
        _timer = timer;
        _characterFactory = characterFactory;
        _coroutineStarter = coroutineStarter;

        _gameConfig = Resources.Load<GameConfig>("Configs/GameConfig");
        
        if(_gameConfig == null)
            throw new Exception("GameConfig not found");
    }

    public bool IsGamePlaying { get; private set; }

    public IEnumerator Preparation()
    {
        yield return SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);

        LevelBound levelBound = Object.FindObjectOfType<LevelBound>();

        if (levelBound == null)
            throw new Exception("Level bound not found");
        
        yield return CreatePlayer();

        _enemySpawner = new EnemySpawner(
            _gameConfig.TimeToEnemySpawn, 
            _controllersFactory, 
            _updateService, 
            levelBound,
            _timer,
            _coroutineStarter,
            AddKillCount);
        
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
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>("Configs/PlayerConfig");
        
        if(characterConfig == null)
            throw new Exception("PlayerConfig not found");

        Character player =
            _characterFactory.CreateCharacter(GameObject.FindWithTag("PlayerStartPoint").transform.position,
                characterConfig);

        PlayerInput playerInput = new PlayerInput();

        _playerController = _controllersFactory.CreatePlayerController(player, playerInput);
        _updateService.Add(_playerController);
        
        _updateService.Add(_controllersFactory.CreateFeatureController(player, playerInput));

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
