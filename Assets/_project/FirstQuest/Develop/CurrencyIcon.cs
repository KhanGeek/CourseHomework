using System;
using UnityEngine;

[Serializable]
public class CurrencyIcon
{
    [SerializeField] private Currencies _type;
    [SerializeField] private Sprite _icon;
    
    public Currencies Type => _type;
    public Sprite Icon => _icon;
}
