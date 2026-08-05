using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public void Start() => _wallet.Initialized();
}
