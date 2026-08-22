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
    
    private bool _isGamePlaying;

    private Action _winRule;
    
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
            _coroutineStarter);
    }

    public void SetGameRule()
    {
        switch (_gameConfig.VictoryCondition)
        {
            case VictoryCondition.KillEnemies:
                
                break;
            
            case VictoryCondition.SurviveForSeconds:
                
                break;
            
            default:
                throw new ArgumentOutOfRangeException("VictoryCondition");
        }

        switch (_gameConfig.DefeatCondition)
        {
            case DefeatCondition.PlayerDied:
                
                break;
            
            case DefeatCondition.MoreThanEnemies:
                
                break;
            
            default:
                throw new ArgumentOutOfRangeException("DefeatCondition");
        }
    }

    private void Stop()
    {
        _playerController.Dispose();
        _enemySpawner.Dispose();
    }

    private void Start()
    {
        _isGamePlaying = true;
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
}
