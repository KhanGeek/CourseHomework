using System;
using UnityEngine;

public class FireFeature : IFeature
{
    private IFeatureActivator _featureActivator;
    private FireBall _fireBallPrefab;

    public FireFeature()
    {
        _fireBallPrefab = Resources.Load<FireBall>("FireBall");
    }

    public void Activate()
    {
        
    }
}
