using System;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class Interactor : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    
    private IInputService _inputService;
    
    private GrabEffect _grabEffect;
    private ExplosionEffect _explosionEffect;
    
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionParticle;

    private void Awake()
    {
        _inputService = new PlayerInput();
        _explosionEffect = new ExplosionEffect(_explosionRadius, _explosionForce, _explosionParticle);
    }

    private void Start()
    {
        _cameraSwitcher.Initialize(_inputService);
    }

    private void Update()
    {
        if (_inputService.PullObject())
        {

            if (_grabEffect == null)
            {
                if (Physics.Raycast(_inputService.GetRayFromScreenPoint(), out RaycastHit grabHit))
                {
                    IGrabbable grabbable = grabHit.collider.GetComponent<IGrabbable>();

                    if (grabbable != null)
                    {
                        _grabEffect = new GrabEffect(grabbable);
                        _grabEffect.Start();
                    }
                }
            }
            else
            {
                _grabEffect.Update(_inputService.GetRayFromScreenPoint());
            }

        }

        if (_inputService.ThrowObject() && _grabEffect != null)
        {
            _grabEffect.Stop();
            _grabEffect = null;
        }
        
        if (_inputService.BlowUp() && Physics.Raycast(_inputService.GetRayFromScreenPoint(), out RaycastHit explosionHit))
        {
            _explosionEffect.Explosion(explosionHit.point);
        }
    }
}
