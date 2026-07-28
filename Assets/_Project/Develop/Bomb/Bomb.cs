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
        IDamageble damageble = other.GetComponent<IDamageble>();

        if (damageble == null)
            return;

        _countdown = StartCoroutine(CountdownToExplosion());
    }

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IDamageble damageble = collider.GetComponent<IDamageble>();

            if (damageble != null)
            {
                damageble.TakeDamage(_damage);
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
