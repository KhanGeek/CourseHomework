using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LoadingPopup _loadingPopup;

    private CharacterFactory _characterFactory;
    private ControllersFactory _controllersFactory;
    private PlayerFactory _playerFactory;
    private UpdateService _updateService;
    private PlayerInput _playerInput;
    private ResourcesLoadService _resourcesLoadService;
    ObjectSearchService _searchService;

    private GameLoop _gameLoop;

    private void Awake() => StartCoroutine(StartProcess());

    private IEnumerator StartProcess()
    {
        _loadingPopup.Show();

        yield return new WaitForSeconds(2f);

        _resourcesLoadService = new ResourcesLoadService();
        _characterFactory = new CharacterFactory();
        _controllersFactory = new ControllersFactory(_characterFactory, _resourcesLoadService);
        _updateService = new UpdateService();
        _playerInput = new PlayerInput();
        _searchService = new ObjectSearchService();
        
        _playerFactory=new PlayerFactory(
            _resourcesLoadService, 
            _characterFactory,
            _updateService,
            _playerInput,
            _searchService,
            _controllersFactory);

        Timer timer = new Timer(this);

        _gameLoop = new GameLoop(
            _updateService,
            _controllersFactory,
            timer,
            this,
            _searchService,
            _resourcesLoadService,
            _playerFactory);

        yield return _gameLoop.Preparation();
        
        _loadingPopup.Hide();
    }

    private void Update()
    {
        if (_gameLoop !=null && _gameLoop.IsGamePlaying)
            _updateService?.Update(Time.deltaTime);
    }
}