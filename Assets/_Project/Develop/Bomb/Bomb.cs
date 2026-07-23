using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _explosionRadius;

    [SerializeField] private float _timeToExplode;
    private float currentTime;


    private bool _isActive;

    private void Update()
    {
        if (_isActive == false)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Explosion();
            
            Destroy(this);
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
       // Collider[] collider=Physics.SphereCast(transform.position, _explosionRadius, transform.up, out RaycastHit hit);
    }
}
