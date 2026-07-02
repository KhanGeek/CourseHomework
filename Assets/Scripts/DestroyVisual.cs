using UnityEngine;

public class DestroyVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    private void OnDestroy() => Instantiate(particles, transform.position, transform.rotation);
}
