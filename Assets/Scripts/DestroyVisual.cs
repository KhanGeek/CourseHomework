using UnityEngine;

public class DestroyVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    public void ParticlesPlay() => Instantiate(particles, transform.position, transform.rotation);
}
