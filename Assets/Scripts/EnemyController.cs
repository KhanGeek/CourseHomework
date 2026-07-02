using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : InputBehavior
{
    private IIdleBehavior _idleBehavior;
    private IReactionBehavior _reactionBehavior;
    
    
    
    public void Initialized(IIdleBehavior idleBehavior, IReactionBehavior reactionBehavior)
    {
        _idleBehavior = idleBehavior;
        _reactionBehavior = reactionBehavior;
    }

    private void Update()
    {
        
    }
}
