using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Image _icon;

    private IReadOnlyReactiveVariable<int> _value;

    public void ChangeValue(int value) => _valueText.text = value.ToString();

    public void Initialize(string type, IReadOnlyReactiveVariable<int> value, Sprite icon)
    {
        _nameText.text = type;
        _icon.sprite = icon;
        _value = value;
        
        _value.Changed += ChangeValue;
        
        ChangeValue(_value.Value);
    }

    private void OnDestroy()
    {
        _value.Changed -= ChangeValue;
    }
}