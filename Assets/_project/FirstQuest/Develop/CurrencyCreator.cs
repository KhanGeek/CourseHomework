using UnityEngine;

public class CurrencyCreator : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Sprite CoinsCurrencyIcon;
    [SerializeField] private Sprite DiamondsCurrencyIcon;
    [SerializeField] private Sprite EnergyCurrencyIcon;

    private void Start()
    {
        _wallet.AddCurrencyToWallet(CreateCurrency(Wallet.CoinsCurrencyName));
        _wallet.AddCurrencyToWallet(CreateCurrency(Wallet.DiamondsCurrencyName));
        _wallet.AddCurrencyToWallet(CreateCurrency(Wallet.EnergyCurrencyName));
    }

    private Currency CreateCurrency(string currencyName)
    {
        Sprite icon = default(Sprite);

        switch (currencyName)
        {
            case Wallet.CoinsCurrencyName:
                icon = CoinsCurrencyIcon;
                break;

            case Wallet.DiamondsCurrencyName:
                icon = DiamondsCurrencyIcon;
                break;

            case Wallet.EnergyCurrencyName:
                icon = EnergyCurrencyIcon;
                break;
        }

        return new Currency(currencyName, icon);
    }
}
