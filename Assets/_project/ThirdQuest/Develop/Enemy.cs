using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isDead;
    private float _lifeTime;
    
    public bool IsDead => _isDead;
    
    public float LifeTime => _lifeTime;

    private void Update() => _lifeTime += Time.deltaTime;
}
