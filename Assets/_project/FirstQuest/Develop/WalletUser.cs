using UnityEngine;

public class WalletUser : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.AddValue(5, Wallet.CoinsCurrencyName);
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.AddValue(5, Wallet.DiamondsCurrencyName);
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.AddValue(5, Wallet.EnergyCurrencyName);
    }
}