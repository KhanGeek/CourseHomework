using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactPursuitBehavior : IReactionBehavior
{
    public void Update(Transform transform, Transform target, ref Vector3 direction)
    {
        direction = target.position - transform.position;
    }
}
