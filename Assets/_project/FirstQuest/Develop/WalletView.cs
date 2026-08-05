using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    
    [SerializeField] private CurrencyView _currencyViewPrefab;

    private List<CurrencyView> _currencyViews;
    
    private void Awake()
    {
        _currencyViews = new List<CurrencyView>();
        
        _wallet.NewCurrencyToWallet += OnNewCurrencyToWallet;
        _wallet.CurrencyValueChange += OnCurrencyValueChange;
    }

    private void OnNewCurrencyToWallet(string name, Sprite icon, int value)
    {
        CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform);
        currencyView.Initialized(name, value, icon);
        
        _currencyViews.Add(currencyView);
    }

    private void OnDestroy()
    {
        _wallet.NewCurrencyToWallet -= OnNewCurrencyToWallet;
        _wallet.CurrencyValueChange -= OnCurrencyValueChange;
    }

    private void OnCurrencyValueChange(string currencyName, int value)
    {
        foreach (CurrencyView currencyView in _currencyViews)
            if(currencyView.Name == currencyName)
                currencyView.ChandeValue(value);
    }
}