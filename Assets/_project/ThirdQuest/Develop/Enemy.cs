using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isDead;
    
    public bool IsDead => _isDead;
}
