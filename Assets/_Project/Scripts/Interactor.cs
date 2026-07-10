using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    private Raycaster _raycaster;
    private IInputService _inputService;
    
    private GrabEffect _grabEffect;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionParticle;

    private void Awake()
    {
        _raycaster = new Raycaster();
        _inputService = new PlayerInput();
    }

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButton))
        {
            if (_grabEffect == null)
            {
                _grabEffect = new GrabEffect();
                _raycaster.StartEffect(_grabEffect, _raycaster.EmitRay(GetRayFromScreenPoint()));

                if (_grabEffect.IsGrabbableObject == false)
                {
                    _grabEffect = null;
                    return;
                }
            }
            else
            {
                _grabEffect.Lounch(_raycaster.EmitRay(GetRayFromScreenPoint()));
            }
        }

        if (Input.GetMouseButtonUp(LeftMouseButton))
        {
            _grabEffect = null;
        }
        
        if (Input.GetMouseButtonDown(RightMouseButton))
        {
            _raycaster.StartEffect(new ExplosionEffect(_explosionRadius, _explosionForce), 
                _raycaster.EmitRay(GetRayFromScreenPoint()));
            
            Instantiate(_explosionParticle, _raycaster.EmitRay(GetRayFromScreenPoint()).point, Quaternion.identity);
            //оказалось что Instantiate наследуется от монобеха, а как прокинуть его до эффекта я не знаю(
        }
    }

    private Ray GetRayFromScreenPoint() => Camera.main.ScreenPointToRay(_inputService.GetInputPosition());
}
