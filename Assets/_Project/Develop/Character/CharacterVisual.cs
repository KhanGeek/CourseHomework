using System.Collections;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    private const string WhondedLayerName = "Whonded";
    private const string DissolveMaterialParameter = "_Alpha_Clip_Threshold";
    private readonly int _velocity = Animator.StringToHash("Velocity");
    private readonly int _die = Animator.StringToHash("Die");
    private readonly int _hit = Animator.StringToHash("Hit");
    private readonly int _jump = Animator.StringToHash("Jump");

    [SerializeField] private SkinnedMeshRenderer _meshRenderer;

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    
    private bool _isWounded;
    private bool _isDie;

    private void Update()
    {
        if (_isDie)
            return;
        
        if (_character.IsDead)
        {
            Die();
            return;
        }

        if (_character.IsWounded)
            SetWounded();

        _animator.SetBool(_jump, _character.IsJump);
        _animator.SetFloat(_velocity, _character.CurrentVelocity);
    }

    public void Die()
    {
        _animator.SetTrigger(_die);
        _isDie = true;
        StartDissolve();
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

    public void StartDissolve()
    {
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        float progress = 0;

        while (progress <= 1)
        {
            _meshRenderer.material.SetFloat(DissolveMaterialParameter, progress);
            progress += Time.deltaTime * 0.5f;
            yield return null;
        }
    }
}
