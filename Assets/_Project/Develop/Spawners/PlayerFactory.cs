public class PlayerFactory
{
    private ResourcesLoadService _resourcesLoadService;
    private ObjectSearchService _searchService;
    private CharacterFactory _characterFactory;
    private ControllersFactory _controllersFactory;
    private UpdateService _updateService;
    private PlayerInput _playerInput;

    public PlayerFactory(ResourcesLoadService resourcesLoadService, CharacterFactory characterFactory, UpdateService updateService, PlayerInput playerInput, ObjectSearchService searchService, ControllersFactory controllersFactory)
    {
        _resourcesLoadService = resourcesLoadService;
        _characterFactory = characterFactory;
        _updateService = updateService;
        _playerInput = playerInput;
        _searchService = searchService;
        _controllersFactory = controllersFactory;
    }

    public PlayerController CreatePlayer()
    {
        CharacterConfig characterConfig = _resourcesLoadService.LoadPlayerConfig();
            
        Character player = _characterFactory.CreateCharacter(_searchService.FindPlayerSpawnPointPosition(),
                characterConfig);

        PlayerController playerController = _controllersFactory.CreatePlayerController(player, _playerInput);
        
        _updateService.Add(playerController);
        
        _updateService.Add(_controllersFactory.CreateFeatureController(player, _playerInput));
        
        return playerController;
    }
}
