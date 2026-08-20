using System;
using Cinemachine;
using UnityEngine;
using Object = UnityEngine.Object;

public class ControllersFactory
{
    private CharacterFactory _characterFactory;
    private CharacterConfig _enemyConfig;

    public ControllersFactory(CharacterFactory characterFactory)
    {
        _characterFactory = characterFactory;
        
        _enemyConfig = Resources.Load<CharacterConfig>("Configs/EnemyConfig");

        if (_enemyConfig == null)
            throw new Exception("EnemyConfig not found");
    }

    public PlayerController CreatePlayerController(Vector3 spawnPosition)
    {
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>("Configs/PlayerConfig");
        
        if(characterConfig == null)
            throw new Exception("PlayerConfig not found");

        PlayerInput playerInput = new PlayerInput();
        
        PlayerController playerController = new PlayerController(
            _characterFactory.CreateCharacter(spawnPosition, characterConfig),
            playerInput, playerInput);
        
        playerController.SetFeature(new FireFeature(playerController.CharacterTransform));
        
        CinemachineVirtualCamera playerCameraPrefab = Resources.Load<CinemachineVirtualCamera>("Prefabs/PlayerCamera");
        CinemachineVirtualCamera playerCamera = Object.Instantiate(playerCameraPrefab);
        playerCamera.Follow = playerController.CharacterTransform;

        return playerController;
    }

    public EnemyController CreateEnemyController(Vector3 spawnPosition, LevelBound levelBound, Timer timer)
    {
        EnemyController enemyController = new EnemyController(
            _characterFactory.CreateCharacter(spawnPosition, _enemyConfig),
            levelBound,
            timer,
            _enemyConfig.TimeToNextTarget);

        return enemyController;
    }
}