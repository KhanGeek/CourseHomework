using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _playerCharacter;
    [SerializeField] private Character _enemyCharacter;
    [SerializeField] private CharacterAgent _enemyAgentCharacter;
    

    private Controller _characterController;
    private Controller _enemyController;
    private Controller _enemyAgentController;

    private void Awake()
    {
        _characterController = new CombinateController(
            new PlayerMovableCharacterController(_playerCharacter),
            new AlongMovableVelosityRotatableController(_playerCharacter, _playerCharacter));
        
        _characterController.Enable();

        NavMeshQueryFilter filter = new NavMeshQueryFilter();
        filter.agentTypeID = 0;
        filter.areaMask = NavMesh.AllAreas;
        
        _enemyController = new CombinateController(
            new DirectionalMovableAgroController(_enemyCharacter, 
                _playerCharacter.transform, 
                30f, 
                2f,
                filter,
                1f),
            new AlongMovableVelosityRotatableController(_enemyCharacter, _enemyCharacter));
        
        _enemyController.Enable();

        _enemyAgentController = new AgentCharacterAgroController(
            _enemyAgentCharacter, 
            _playerCharacter.transform,
            30f,
            2f,
            1f);
        
        _enemyAgentController.Enable();
    }

    private void Start()
    {
        _enemyCharacter.gameObject.SetActive(false);
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
        _enemyController.Update(Time.deltaTime);
        _enemyAgentController.Update(Time.deltaTime);
    }
}