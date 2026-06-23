using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Item
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    
    public override void Use()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRigidbody = bullet.transform.GetComponent<Rigidbody>();
        
        bulletRigidbody.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
    }
}
