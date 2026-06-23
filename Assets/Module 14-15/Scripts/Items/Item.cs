using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public abstract void Use();

    public void OnDestroy()
    {
        ParticleSystem particle = Instantiate(_particle, transform.position, transform.rotation);
        particle.Play();
    }
}
