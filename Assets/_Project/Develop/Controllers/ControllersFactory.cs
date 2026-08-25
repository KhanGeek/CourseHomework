using System;
using Cinemachine;
using UnityEngine;
using Object = UnityEngine.Object;

public class ControllersFactory
{
    private CharacterFactory _characterFactory;
    private ResourcesLoadService _resourcesLoadService;

    public ControllersFactory(CharacterFactory characterFactory, ResourcesLoadService resourcesLoadService)
    {
        _characterFactory = characterFactory;
        _resourcesLoadService = resourcesLoadService;
    }

    public PlayerController CreatePlayerController(Character character, IMovementInput movementInput)
    {
        PlayerController playerController = new PlayerController(
            character,
            movementInput);

        CinemachineVirtualCamera playerCameraPrefab = _resourcesLoadService.LoadCinemachineCameraPrefab();
        CinemachineVirtualCamera playerCamera = Object.Instantiate(playerCameraPrefab);
        playerCamera.Follow = character.transform;

        return playerController;
    }

    public FeatureController CreateFeatureController(Character character, IFeatureActivator featureActivator)
    {
        FeatureController featureController = new FeatureController(featureActivator, character);
        
        featureController.SetFeature(new FireFeature(_resourcesLoadService.LoadFireBallPrefab()));
        
        return featureController;
    }

    public EnemyController CreateEnemyController(Vector3 spawnPosition, LevelBound levelBound, Timer timer, Action killAction)
    {
        CharacterConfig enemyConfig = _resourcesLoadService.LoadEnemyConfig();
        
        Character enemy = _characterFactory.CreateCharacter(spawnPosition, enemyConfig);
        
        EnemyController enemyController = new EnemyController(
            enemy,
            levelBound,
            timer,
            enemyConfig.TimeToNextTarget,
            killAction);
        
        enemy.gameObject.AddComponent<DamageDealing>().Initialize(enemyConfig.Damage);

        return enemyController;
    }
}