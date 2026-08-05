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
    
    private List<Currency> _currencies;

    private void Awake()
    {
        _currencies = new List<Currency>();
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
                CurrencyValueChange?.Invoke(currencyName, currency.Value);
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
                    CurrencyValueChange?.Invoke(currencyName, currency.Value);
        }
    }

    public void AddCurrencyToWallet(Currency currency)
    {
        _currencies.Add(currency);
        NewCurrencyToWallet?.Invoke(currency.Name, currency.Icon, currency.Value);
    }
}
