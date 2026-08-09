using System;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private readonly int IsGroundKey = Animator.StringToHash("IsGround");
    private readonly int VelocityXKey = Animator.StringToHash("VelocityX");
    private readonly int VelocityYKey = Animator.StringToHash("VelocityY");
    private readonly int DieKey = Animator.StringToHash("Die");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character  _character;
    [SerializeField] private Health _health;

    private void Start() => _health.Died += OnDied;

    private void OnDestroy() => _health.Died -= OnDied;

    private void OnDied() => _animator.SetTrigger(DieKey);

    private void Update()
    {
        Vector2 velocity = _character.Velocity;
        
        _animator.SetFloat(VelocityXKey, MathF.Abs(velocity.x));
        _animator.SetFloat(VelocityYKey, velocity.y);
        
        _animator.SetBool(IsGroundKey, _character.IsGround);
    }
}