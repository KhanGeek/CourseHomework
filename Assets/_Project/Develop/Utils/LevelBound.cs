using UnityEngine;

public class LevelBound : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), 0,
            Random.Range(_collider.bounds.min.z, _collider.bounds.max.z));
    }
}
