using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private SphereCollider _collider;

    public bool IsPlayerDetected { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInput playerInput))
            IsPlayerDetected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInput playerInput))
            IsPlayerDetected = false;
    }

    private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, _collider.radius);
}