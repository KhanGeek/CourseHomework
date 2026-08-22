using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LoadingPopup _loadingPopup;
    
    private CharacterFactory _characterFactory;
    private ControllersFactory _controllersFactory;
    private UpdateService _updateService;
    
    private GameLoop _gameLoop;

    private void Awake() => StartCoroutine(StartProcess());

    private IEnumerator StartProcess()
    {
        _loadingPopup.Show();
        
        _characterFactory = new CharacterFactory();
        _controllersFactory =new ControllersFactory(_characterFactory);
        _updateService = new UpdateService();

        Timer timer = new Timer(this);

        _gameLoop = new GameLoop(
            _updateService, 
            _controllersFactory, 
            timer, 
            _characterFactory, 
            this);

        yield return _gameLoop.Preparation();

        yield return new WaitForSeconds(2f);
        
        _loadingPopup.Hide();
    }

    private void Update()
    {
        _updateService?.Update(Time.deltaTime);
    }
}
