using System;
using Cinemachine;
using UnityEngine;
using Object = UnityEngine.Object;

public class ControllersFactory
{
    private CharacterConfig _enemyConfig;
    private CharacterFactory _characterFactory;

    public ControllersFactory(CharacterFactory characterFactory)
    {
        _characterFactory = characterFactory;
        _enemyConfig = Resources.Load<CharacterConfig>("Configs/EnemyConfig");

        if (_enemyConfig == null)
            throw new Exception("EnemyConfig not found");
    }

    public PlayerController CreatePlayerController(Character character, IMovementInput movementInput)
    {
        PlayerController playerController = new PlayerController(
            character,
            movementInput);
        
        CinemachineVirtualCamera playerCameraPrefab = Resources.Load<CinemachineVirtualCamera>("Prefabs/PlayerCamera");
        CinemachineVirtualCamera playerCamera = Object.Instantiate(playerCameraPrefab);
        playerCamera.Follow = character.transform;

        return playerController;
    }

    public FeatureController CreateFeatureController(Character character, IFeatureActivator featureActivator)
    {
        FeatureController featureController = new FeatureController(featureActivator, character);
        
        featureController.SetFeature(new FireFeature());
        
        return featureController;
    }

    public EnemyController CreateEnemyController(Vector3 spawnPosition, LevelBound levelBound, Timer timer)
    {
        Character enemy = _characterFactory.CreateCharacter(spawnPosition, _enemyConfig);
        
        EnemyController enemyController = new EnemyController(
            enemy,
            levelBound,
            timer,
            _enemyConfig.TimeToNextTarget);
        
        enemy.gameObject.AddComponent<DamageDealing>().Initialize(_enemyConfig.Damage);

        return enemyController;
    }
}