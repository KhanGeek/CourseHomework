using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private List<CurrencyIcon> _currencyIcons;
    [SerializeField] private CurrencyView _currencyViewPrefab;
    
    private Wallet _wallet;

    private Dictionary<Currencies, CurrencyView> _currencyViews;
    
    private void OnNewCurrencyAdded(Currencies type, int value)
    {
        CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform);
        currencyView.Initialize(type.ToString(), value, GetIcon(type));
        
        _currencyViews.Add(type, currencyView);
    }

    private void OnDestroy()
    {
        _wallet.NewCurrencyAdded -= OnNewCurrencyAdded;
        _wallet.CurrencyValueChanged -= OnCurrencyValueChanged;
    }

    public void Initialize(Wallet wallet)
    {
        _currencyViews = new Dictionary<Currencies, CurrencyView>();
        _wallet = wallet;
        
        _wallet.NewCurrencyAdded += OnNewCurrencyAdded;
        _wallet.CurrencyValueChanged += OnCurrencyValueChanged;
    }

    private void OnCurrencyValueChanged(Currencies type, int value)
    {
        if(_currencyViews.TryGetValue(type, out CurrencyView currencyView))
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