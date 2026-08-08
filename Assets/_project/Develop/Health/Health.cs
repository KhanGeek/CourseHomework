using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Died;

    private bool _isDead;
    public bool IsDead => _isDead;

    public void Die()
    {
        if (IsDead)
            return;

        _isDead = true;
        Died?.Invoke();
    }
    
    public void Ressurect() => _isDead = false;
}
