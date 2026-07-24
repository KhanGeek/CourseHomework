using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private float _timeToExplode;
    private float currentTime;

    [SerializeField] private BombVisual _bombVisual;
    
    private bool _isActive;

    private void Update()
    {
        if (_isActive == false)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Explosion();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageble damageble = other.GetComponent<IDamageble>();

        if (damageble == null)
            return;
        
        _isActive = true;
        currentTime=_timeToExplode;
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

    private void OnDrawGizmos()
    {
        if(_isActive)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _explosionRadius);
        }
    }
}
