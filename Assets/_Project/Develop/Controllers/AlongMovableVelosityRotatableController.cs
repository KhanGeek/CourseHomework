public class AlongMovableVelosityRotatableController : Controller
{
    private IMovable _movable;
    private IRotatable _rotatable;

    public AlongMovableVelosityRotatableController(IMovable movable, IRotatable rotatable)
    {
        _movable = movable;
        _rotatable = rotatable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _rotatable.SetRotationDirection(_movable.CurrentVelocity);
    }
}