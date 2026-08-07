using System;
using UnityEngine;

public class CurrencyService : MonoBehaviour
{
    public event Action<Currencies, int> NewCurrencyAdded
    {
        add => _wallet.NewCurrencyAdded+= value;
        remove => _wallet.NewCurrencyAdded -= value;
    }
    
    public event Action<Currencies, int> CurrencyValueChanged
    {
        add => _wallet.CurrencyValueChanged += value;
        remove => _wallet.CurrencyValueChanged -= value;
    }
    
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    private void Start()
    {
        _wallet.AddCurrencyToWallet(new Currency(Currencies.Coins));
        _wallet.AddCurrencyToWallet(new Currency(Currencies.Diamonds));
        _wallet.AddCurrencyToWallet(new Currency(Currencies.Energy));
    }

    public void AddAmount(int amount, Currencies type) => _wallet.AddValue(amount, type);

    public void SubtractAmount(int amount, Currencies type) => _wallet.SubtractValue(amount, type);
}
