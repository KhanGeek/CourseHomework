using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    public void Explosion()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }
}
