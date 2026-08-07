using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private List<CurrencyIcon> _currencyIcons;
    [SerializeField] private CurrencyService _currencyService;
    [SerializeField] private CurrencyView _currencyViewPrefab;

    private List<CurrencyView> _currencyViews;
    
    private void Start()
    {
        _currencyViews = new List<CurrencyView>();
        
        _currencyService.NewCurrencyAdded += OnNewCurrencyAdded;
        _currencyService.CurrencyValueChanged += OnCurrencyValueChanged;
    }

    private void OnNewCurrencyAdded(Currencies type, int value)
    {
        CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform);
        currencyView.Initialize(type, value, GetIcon(type));
        
        _currencyViews.Add(currencyView);
    }

    private void OnDestroy()
    {
        _currencyService.NewCurrencyAdded -= OnNewCurrencyAdded;
        _currencyService.CurrencyValueChanged -= OnCurrencyValueChanged;
    }

    private void OnCurrencyValueChanged(Currencies type, int value)
    {
        foreach (CurrencyView currencyView in _currencyViews)
            if(currencyView.Type == type)
                currencyView.ChangeValue(value);
    }

    private Sprite GetIcon(Currencies type)
    {
        foreach (CurrencyIcon currencyIcon in _currencyIcons)
        {
            if(currencyIcon.Type == type)
                return currencyIcon.Icon;
        }
        
        Debug.LogWarning("No such currency: " + type);
        return null;
    }
}