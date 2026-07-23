using System;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    private const string WhondedLayerName = "Whonded";
    private readonly int _velocity = Animator.StringToHash("Velocity");
    private readonly int _die = Animator.StringToHash("Die");
    private readonly int _hit = Animator.StringToHash("Hit");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    
    private bool _isWounded;
    private bool _isDie;

    private void Update()
    {
        if (_isDie)
            return;
        
        _animator.SetFloat(_velocity, _character.CurrentVelocity);
    }

    public void Die()
    {
        _animator.SetTrigger(_die);
        _isDie = true;
    }

    public void Hit()
    {
        if (_isDie)
            return;
        
        _animator.SetTrigger(_hit);
    }

    public void SetWounded()
    {
        if (_isWounded)
            return;
        
        int whondedLayer = _animator.GetLayerIndex(WhondedLayerName);
        
        if (whondedLayer != -1)
            _animator.SetLayerWeight(whondedLayer, 1f);
            
        _isWounded = true;
    }
}
