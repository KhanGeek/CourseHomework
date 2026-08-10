using System;
using UnityEngine;

public class CurrencyService : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    
    private Wallet _wallet;

    private void Start()
    {
        _wallet = new Wallet();
        
        _walletView.Initialize(_wallet);
        
        _wallet.AddCurrencyToWallet(new Currency(Currencies.Coins));
        _wallet.AddCurrencyToWallet(new Currency(Currencies.Diamonds));
        _wallet.AddCurrencyToWallet(new Currency(Currencies.Energy));
    }

    public void AddAmount(int amount, Currencies type) => _wallet.AddValue(amount, type);

    public void SubtractAmount(int amount, Currencies type) => _wallet.SubtractValue(amount, type);
}
