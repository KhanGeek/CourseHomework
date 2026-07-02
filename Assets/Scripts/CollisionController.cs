using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private SphereCollider _collider;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInput playerInput))
            _enemyController.ReactActive(playerInput.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInput playerInput))
            _enemyController.ReactDisabled();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _collider.radius);
    }
}