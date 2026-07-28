using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _timeToExplode;
    [SerializeField] private BombVisual _bombVisual;

    private Coroutine _countdown;
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable == null)
            return;

        _countdown = StartCoroutine(CountdownToExplosion());
        _bombVisual.StartCountdown();
    }

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(_damage);
            }
        }
        
        _bombVisual.Explosion();
    }

    private IEnumerator CountdownToExplosion()
    {
        yield return new WaitForSeconds(_timeToExplode);
        Explosion();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if(_countdown != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _explosionRadius);
        }
    }
}
