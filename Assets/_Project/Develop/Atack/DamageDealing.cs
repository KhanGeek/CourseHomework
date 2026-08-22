using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    private float _damage;
    
    public void Initialize(float damage)
    {
        _damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.TryGetComponent(out IDamageble damageable);
        
        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
    }
}
