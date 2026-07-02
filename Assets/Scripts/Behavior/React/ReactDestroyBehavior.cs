using UnityEngine;

public class ReactDestroyBehavior:IReactionBehavior
{
    public void Update(Transform transform, Transform target, ref Vector3 direction)
    {
        transform.GetComponent<EnemyController>().Destroy();
    }
}