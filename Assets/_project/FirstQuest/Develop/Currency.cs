public class Currency
{
    private Currencies _type;
    private ReactiveVariable<int> _value;

    public Currency(Currencies type, int value = 0)
    {
        _type = type;
        _value = new ReactiveVariable<int>(value);
    }

    public IReadOnlyReactiveVariable<int> Value => _value;
    
    public Currencies Type => _type;
    
    public void AddValue(int value) => _value.Value += value;

    public void SubtractValue(int value) => _value.Value -= value;

    public bool CanAfford(int value) => _value.Value >= value;
}
