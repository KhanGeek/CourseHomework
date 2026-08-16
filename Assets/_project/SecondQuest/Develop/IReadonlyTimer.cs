public interface IReadonlyTimer
{
    IReadOnlyReactiveVariable<float> CurrentTime { get; }
    IReadOnlyReactiveVariable<float> StartTime{ get; }
}