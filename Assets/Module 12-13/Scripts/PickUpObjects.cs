using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickUpObjects : MonoBehaviour
{
    [SerializeField] private GameLoop _gameLoop;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        
        if (coin == null)
            return;
        
        _gameLoop.DeletCoin(coin);
        coin.gameObject.SetActive(false);
    }
}
