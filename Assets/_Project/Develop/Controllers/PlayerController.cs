using System;
using UnityEngine;

public class PlayerController: IUpdatable, IDisposable
{
    public event Action<IUpdatable> Destroy;
    
    private Character _character;
    private IMovementInput _movementInput;
    private IFeatureActivator _featureActivator;
    private IFeature _feature;

    public PlayerController(Character character, IMovementInput movementInput, IFeatureActivator featureActivator)
    {
        _character = character;
        _movementInput = movementInput;
        _featureActivator = featureActivator;
    }

    public void SetFeature(IFeature feature) => _feature = feature;
    
    public Transform CharacterTransform => _character.transform;

    public void Update(float deltaTime)
    {
        _character.SetDirection(_movementInput.GetDirection());
        
        if(_featureActivator.Activate())
            _feature?.Activate();
    }

    public void Dispose() => Destroy?.Invoke(this);
}
