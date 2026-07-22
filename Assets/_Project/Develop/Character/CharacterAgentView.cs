using UnityEngine;

public class CharacterAgentView : MonoBehaviour
{
    private readonly int IsRuningKey = Animator.StringToHash("isRuning");
    
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterAgent _character;

    private void Update()
    {
        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void StartRunning() => _animator.SetBool(IsRuningKey, true);

    private void StopRunning() => _animator.SetBool(IsRuningKey, false);
}
