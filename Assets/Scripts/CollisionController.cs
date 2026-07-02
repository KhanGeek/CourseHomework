using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerInput playerInput))
            _enemyController.ReactActive(playerInput.transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerInput playerInput))
            _enemyController.ReactDisabled();
    }
}
