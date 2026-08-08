using UnityEngine;

public class GameZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Health health))
            health.Die();
    }
}
