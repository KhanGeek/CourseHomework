using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private GameObject _playerVisual;
    [SerializeField] private PlayerController _player;
    [SerializeField] private ParticleSystem _jumpParticles;

    private Vector3 _offset;
    private float _rotationSpeed = 60f;
    
    private void Start() => _offset = new Vector3(0f, transform.localScale.y / 2, 0f);

    private void LateUpdate()
    {
        _playerVisual.transform.position = transform.position - _offset;
        _playerVisual.transform.rotation = Quaternion.RotateTowards(_playerVisual.transform.rotation,
            Quaternion.LookRotation(_player.GetDirection()), _rotationSpeed * Time.deltaTime);
    }

    public void Jump() => _jumpParticles.Play();
    
    public Transform GetPlayerVisualTransform() => _playerVisual.transform;
}
