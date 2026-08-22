public class PlayerController : Controller
{
    private Character _character;
    private IMovementInput _movementInput;

    public PlayerController(Character character, IMovementInput movementInput) : base(character)
    {
        _character = character;
        _movementInput = movementInput;
    }

    public override void Update(float deltaTime)
    {
        _character.SetDirection(_movementInput.GetDirection());
    }
}