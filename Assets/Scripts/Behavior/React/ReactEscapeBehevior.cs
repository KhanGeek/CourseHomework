using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactEscapeBehevior : IReactionBehavior
{
    public void Update(Transform transform, Transform target, ref Vector3 direction)
    {
        direction = transform.position - target.position;
    }
}
