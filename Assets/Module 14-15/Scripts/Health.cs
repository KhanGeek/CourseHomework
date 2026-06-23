using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    public void AddHealth(int amount)
    {
        if(amount < 0)
            return;
        
        _health += amount;
    }
}
