using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdleBehavior
{
    void Update(Transform transform, ref Vector3 direction);
}