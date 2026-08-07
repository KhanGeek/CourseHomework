using UnityEngine;

public class ObstacleChecker : MonoBehaviour, IObstacleChecker
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private float _distanceToCheck;

    public bool IsTouches => Physics2D.CapsuleCast(_collider.bounds.center, _collider.size, 
        _collider.direction, 0, _direction, _distanceToCheck, _mask);
}
