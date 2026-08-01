using UnityEngine;

public class BombVisual : MonoBehaviour
{
    private const string ActivateShaderCountdown = "_Active";
    
    [SerializeField] private ParticleSystem _particles;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void StartCountdown() => _renderer.material.SetFloat(ActivateShaderCountdown, 1);

    public void Explosion()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
        _audioSource.PlayOneShot(_audioClip);
    }
}
