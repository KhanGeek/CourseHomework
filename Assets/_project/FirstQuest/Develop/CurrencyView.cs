using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Image _icon;

    public string Name => _nameText.text;

    public void ChandeValue(int value) => _valueText.text = value.ToString();

    public void Initialized(string nameText, int value, Sprite icon)
    {
        _nameText.text = nameText;
        _icon.sprite = icon;

        ChandeValue(value);
    }
}
