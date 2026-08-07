public class Currency
{
    private Currencies _type;
    private int _value;

    public Currency(Currencies type, int value = 0)
    {
        _type = type;
        _value = value;
    }

    public int Value => _value;
    
    public Currencies Type => _type;
    
    public void AddValue(int value) => _value += value;

    public void SubtractValue(int value) => _value -= value;

    public bool CanAfford(int value) => _value >= value;
}
