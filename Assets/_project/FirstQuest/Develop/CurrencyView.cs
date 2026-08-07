using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Image _icon;

    public void ChangeValue(int value) => _valueText.text = value.ToString();

    public void Initialize(string type, int value, Sprite icon)
    {
        _nameText.text = type;
        _icon.sprite = icon;

        ChangeValue(value);
    }
    
    
}