using System;
using UnityEngine;

public class Currency
{
    private string _name;
    private int _value;

    private Sprite _icon; 

    public Currency(string name, Sprite icon, int value = 0)
    {
        _name = name;
        _icon = icon;
        _value = value;
    }

    public int Value => _value;
    public string Name => _name;
    
    public Sprite Icon => _icon;
    
    public void AddValue(int value) => _value += value;

    public bool TrySubtractValue(int value)
    {
        if (_value - value < 0)
            return false;
        
        _value -= value;
        return true;
    }
}
