using System;
using Cinemachine;
using UnityEngine;

public class ResourcesLoadService
{
    public CharacterConfig LoadEnemyConfig() => Load<CharacterConfig>("Configs/EnemyConfig");

    public CharacterConfig LoadPlayerConfig() => Load<CharacterConfig>("Configs/PlayerConfig");

    public GameConfig LoadGameConfig() => Load<GameConfig>("Configs/GameConfig");

    public FireBall LoadFireBallPrefab() => Load<FireBall>("Prefabs/FireBall");

    public CinemachineVirtualCamera LoadCinemachineCameraPrefab() =>
        Load<CinemachineVirtualCamera>("Prefabs/PlayerCamera");

    private T Load<T>(string path) where T : UnityEngine.Object
    {
        T loadObject = Resources.Load<T>(path);

        if (loadObject == null)
            throw new Exception(path + "not found");

        return loadObject;
    }
}
