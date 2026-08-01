using System;
using System.Collections;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    private const string WhondedLayerName = "Whonded";
    
    private const string DissolveMaterialParameter = "_Disolve";
    
    private readonly int _velocity = Animator.StringToHash("Velocity");
    private readonly int _die = Animator.StringToHash("Die");
    private readonly int _hit = Animator.StringToHash("Hit");
    private readonly int _jump = Animator.StringToHash("Jump");
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioFootsteps;
    [SerializeField] private float _foodstepPause;

    private YieldInstruction _footstepWaitForNextStep;
    private Coroutine _footstepCoroutine;

    [SerializeField] private SkinnedMeshRenderer _meshRenderer;

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    
    private bool _isWounded;
    private bool _isDie;

    private void Awake()
    {
        _footstepWaitForNextStep = new WaitForSeconds(_foodstepPause);
    }

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

        FootstepAudioControll();

        _animator.SetBool(_jump, _character.IsJump);
        _animator.SetFloat(_velocity, _character.CurrentVelocity);
    }

    public void FootstepAudioControll()
    {
        if(_character.IsFootstep() &&  _footstepCoroutine == null)
            _footstepCoroutine = StartCoroutine(FootstepAudioCoroutine());

        if (_footstepCoroutine != null && _character.IsFootstep() == false)
        {
            StopCoroutine(_footstepCoroutine);
            _footstepCoroutine = null;
        }
    }

    public void Die()
    {
        _animator.SetTrigger(_die);
        _isDie = true;
        
        StopCoroutine(_footstepCoroutine);
        
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
            progress += Time.deltaTime * 0.2f;
            yield return null;
        }
    }

    private IEnumerator FootstepAudioCoroutine()
    {
        while (true)
        {
            yield return _footstepWaitForNextStep;
            _audioSource.PlayOneShot(_audioFootsteps);
        }
    }
}
