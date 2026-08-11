using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<Currencies, IReadOnlyReactiveVariable<int>> NewCurrencyAdded;
    
    private List<Currency> _currencies;

    public Wallet()
    {
        _currencies = new List<Currency>();
    }

    public void AddValue(int value, Currencies type)
    {
        if (value < 0)
        {
            Debug.LogWarning("AddValue - Value cannot be negative");
            return;
        }
        
        foreach (Currency currency in _currencies)
        {
            if (currency.Type == type)
            {
                currency.AddValue(value);
            }
        }
    }

    public void SubtractValue(int value, Currencies type)
    {
        if (value < 0)
        {
            Debug.LogWarning("SubtractValue - Value cannot be negative");
            return;
        }

        foreach (Currency currency in _currencies)
        {
            if (currency.Type == type)
            {
                if (currency.CanAfford(value))
                {
                    currency.SubtractValue(value);
                }
                else
                {
                    Debug.LogWarning("SubtractValue - Value cannot afford value");
                }
            }
        }
    }

    public void AddCurrencyToWallet(Currency currency)
    {
        _currencies.Add(currency);
        NewCurrencyAdded?.Invoke(currency.Type, currency.Value);
    }
}
