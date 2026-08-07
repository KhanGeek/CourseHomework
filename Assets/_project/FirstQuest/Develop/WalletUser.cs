using UnityEngine;

public class WalletUser : MonoBehaviour
{
    [SerializeField] private CurrencyService _currencyService;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            _currencyService.AddAmount(5, Currencies.Coins);
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
            _currencyService.AddAmount(5, Currencies.Diamonds);
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
            _currencyService.AddAmount(5, Currencies.Energy);
        
        if(Input.GetKeyDown(KeyCode.Alpha4))
            _currencyService.SubtractAmount(5, Currencies.Coins);
        
        if(Input.GetKeyDown(KeyCode.Alpha5))
            _currencyService.SubtractAmount(5, Currencies.Diamonds);
        
        if(Input.GetKeyDown(KeyCode.Alpha6))
            _currencyService.SubtractAmount(5, Currencies.Energy);
    }
}