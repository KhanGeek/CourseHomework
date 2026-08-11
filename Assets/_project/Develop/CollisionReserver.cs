using System;
using UnityEngine;

public class CollisionReserver: MonoBehaviour
{
    public event Action Activated;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Character character))
            Activated?.Invoke();
    }
}
