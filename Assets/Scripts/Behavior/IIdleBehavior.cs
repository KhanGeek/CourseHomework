using UnityEngine;

public interface IIdleBehavior
{
    void Update(Transform transform, ref Vector3 direction);
}