using UnityEngine;

public class FireBall:MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _impulseForce;
    [SerializeField] private float _damage;

    public void Fire()
    {
        _rigidbody.AddForce(transform.forward * _impulseForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamageble damageable))
            damageable.TakeDamage(_damage);
            
        Destroy(gameObject);
    }
}
