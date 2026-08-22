public class PlayerController : Controller
{
    private IMovementInput _movementInput;
    
    private float _currentGameTime;

    public PlayerController(Character character, IMovementInput movementInput) : base(character)
    {
        _character = character;
        _movementInput = movementInput;
    }

    public bool IsDead { get; private set; }

    public int CurrentGameTime => (int)_currentGameTime;

    public override void Update(float deltaTime)
    {
        _currentGameTime += deltaTime;
        _character.SetDirection(_movementInput.GetDirection());
    }

    protected override void OnDeath()
    {
        IsDead = true;
        base.OnDeath();
    }
}