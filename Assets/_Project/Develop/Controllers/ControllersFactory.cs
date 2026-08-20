using Cinemachine;
using UnityEngine;

public class ControllersFactory
{
    private CharacterFactory _characterFactory;

    public ControllersFactory(CharacterFactory characterFactory)
    {
        _characterFactory = characterFactory;
    }

    public PlayerController CreatePlayerController(Vector3 spawnPosition)
    {
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>("Configs/PlayerConfig");

        PlayerInput playerInput = new PlayerInput();
        
        PlayerController playerController = new PlayerController(
            _characterFactory.CreateCharacter(spawnPosition, characterConfig),
            playerInput, playerInput);
        
        
        CinemachineVirtualCamera playerCameraPrefab = Resources.Load<CinemachineVirtualCamera>("Prefabs/PlayerCamera");
        CinemachineVirtualCamera playerCamera = Object.Instantiate(playerCameraPrefab);
        playerCamera.Follow = playerController.CharacterTransform;

        return playerController;
    }
}