using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Behaviors _idleBehaviors;
    [SerializeField] private Behaviors _reactBehavior;

    public Transform GetTransform() => transform;
    
    public Behaviors GetIdleBehavior() => _idleBehaviors;
    
    public Behaviors GetReactionBehavior() => _reactBehavior;
}
