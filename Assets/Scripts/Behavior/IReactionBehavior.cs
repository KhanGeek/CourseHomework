using UnityEngine;

public interface IReactionBehavior
{
    void Update(Transform transform, Transform target, ref Vector3 direction);
}