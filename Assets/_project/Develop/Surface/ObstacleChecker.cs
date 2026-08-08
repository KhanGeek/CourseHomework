using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private float _distanceToCheck;

    private ContactFilter2D _filter;
    private RaycastHit2D[] _hits;

    private void Awake()
    {
        _filter = new ContactFilter2D
        {
            useTriggers = false,
            useLayerMask = true,
            layerMask = _mask
        };

        _hits = new RaycastHit2D[1];
    }

    //public bool IsTouches => Physics2D.CapsuleCast(_collider.bounds.center, _collider.size,
    //_collider.direction, 0, _direction, _filter, _hits, _distanceToCheck) > 0;

 //   public bool IsTouches => Physics2D.CapsuleCast(_collider.bounds.center, _collider.size,
   //     _collider.direction, 0, _direction, _distanceToCheck, _mask);

   public bool IsTouches => true;
}
