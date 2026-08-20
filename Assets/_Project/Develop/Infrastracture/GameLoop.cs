using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop
{
    private ControllersFactory _controllersFactory;
    private UpdateService _updateService;
    
    public GameLoop(UpdateService updateService, ControllersFactory controllersFactory)
    {
        _updateService = updateService;
        _controllersFactory = controllersFactory;
    }
    
    public IEnumerator Preparation()
    {
        yield return SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        
        _updateService.Add(_controllersFactory.CreatePlayerController(
            GameObject.FindWithTag("PlayerStartPoint").transform.position));
        
        yield return null;
    }
}
