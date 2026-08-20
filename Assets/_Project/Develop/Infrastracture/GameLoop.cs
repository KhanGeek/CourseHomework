using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class GameLoop
{
    private ControllersFactory _controllersFactory;
    private UpdateService _updateService;
    private Timer _timer;
    
    public GameLoop(UpdateService updateService, ControllersFactory controllersFactory, Timer timer)
    {
        _updateService = updateService;
        _controllersFactory = controllersFactory;
        _timer = timer;
    }

    public IEnumerator Preparation()
    {
        yield return SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);

        LevelBound levelBound = Object.FindObjectOfType<LevelBound>();

        if (levelBound == null)
            throw new Exception("Level bound not found");

        _updateService.Add(_controllersFactory.CreateEnemyController(
            GameObject.FindWithTag("EnemyStartPoint").transform.position, levelBound, _timer));

        _updateService.Add(_controllersFactory.CreatePlayerController(
            GameObject.FindWithTag("PlayerStartPoint").transform.position));
    }
}
