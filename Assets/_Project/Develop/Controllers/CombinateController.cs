public class CombinateController : Controller
{
    private Controller[]  _controllers;

    public CombinateController(params Controller[] controllers)
    {
        _controllers = controllers;
    }

    public override void Enable()
    {
        base.Enable();
        
        foreach (Controller controller in _controllers)
            controller.Enable();
    }

    public override void Disable()
    {
        base.Disable();
        
        foreach (Controller controller in _controllers)
            controller.Disable();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        foreach (Controller controller in _controllers)
            controller.Update(deltaTime);
    }
}
