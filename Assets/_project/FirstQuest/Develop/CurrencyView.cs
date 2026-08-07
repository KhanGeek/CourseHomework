using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Image _icon;
    
    private Currencies _type;

    public Currencies Type => _type;

    public void ChangeValue(int value) => _valueText.text = value.ToString();

    public void Initialize(Currencies type, int value, Sprite icon)
    {
        _type = type;
        _nameText.text = type.ToString();
        _icon.sprite = icon;

        ChangeValue(value);
    }
    
    
}