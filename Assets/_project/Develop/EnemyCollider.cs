using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Character character))
            character.Die();
    }
}
