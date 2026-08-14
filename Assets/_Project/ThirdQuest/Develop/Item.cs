public class Item
{
    private string _name;
    private int _maxStack;
    
    public Item(string name, int maxStack)
    {
        _name = name;
        _maxStack = maxStack;
    }
    
    public string Name=> _name;
    public int MaxStack => _maxStack;
}