using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<String, Sprite, int> NewCurrencyToWallet;
    public event Action<string, int> CurrencyValueChange;

    public const string CoinsCurrencyName = "Coins";
    public const string DiamondsCurrencyName = "Diamonds";
    public const string EnergyCurrencyName = "Energy";

    [SerializeField] private Sprite CoinsCurrencyIcon;
    [SerializeField] private Sprite DiamondsCurrencyIcon;
    [SerializeField] private Sprite EnergyCurrencyIcon;
    
    private List<Currency> _currencies;

    public void Initialized()
    {
        _currencies = new List<Currency>();
        
        AddCurrencyToWallet(CreateCurrency(CoinsCurrencyName));
        AddCurrencyToWallet(CreateCurrency(DiamondsCurrencyName));
        AddCurrencyToWallet(CreateCurrency(EnergyCurrencyName));
    }

    public void AddValue(int value, string currencyName)
    {
        if (value < 0)
        {
            Debug.LogWarning("AddValue - Value cannot be negative");
            return;
        }
        
        foreach (Currency currency in _currencies)
        {
            if (currency.Name == currencyName)
            {
                currency.AddValue(value);
                CurrencyValueChange?.Invoke(currencyName, value);
            }
        }
    }

    public void SubtractValue(int value, string currencyName)
    {
        if (value < 0)
        {
            Debug.LogWarning("SubtractValue - Value cannot be negative");
            return;
        }

        foreach (Currency currency in _currencies)
        {
            if (currency.Name == currencyName)
                if (currency.TrySubtractValue(value) == false)
                    Debug.LogWarning("SubtractValue - insufficient funds");
                else
                    CurrencyValueChange?.Invoke(currencyName, value);
        }
    }

    private void AddCurrencyToWallet(Currency currency)
    {
        _currencies.Add(currency);
        NewCurrencyToWallet?.Invoke(currency.Name, currency.Icon, currency.Value);
    }

    private Currency CreateCurrency(string currencyName)
    {
        Sprite icon = default(Sprite);

        switch (currencyName)
        {
            case CoinsCurrencyName:
                icon = CoinsCurrencyIcon;
                break;
            
            case DiamondsCurrencyName:
                icon = DiamondsCurrencyIcon;
                break;
            
            case EnergyCurrencyName:
                icon = EnergyCurrencyIcon;
                break;
        }
        
        return new Currency(currencyName, icon);
    }
}
