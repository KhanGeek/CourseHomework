using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Controller _characterController;

    private void Awake()
    {
        _characterController = new CombinateController(
            new PlayerRotatableCharacterController(_character),
            new PlayerMovableCharacterController(_character));
        
        _characterController.Enable();
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
    }
}