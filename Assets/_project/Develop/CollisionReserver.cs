using System;
using UnityEngine;

public class CollisionReserver: MonoBehaviour
{
    public event Action Activate;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Character character))
            Activate?.Invoke();
    }
}
