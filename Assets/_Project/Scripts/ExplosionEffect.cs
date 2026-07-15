using UnityEngine;

public class ExplosionEffect
{
    private float _explosionRadius;
    private float _explosionForse;
    private ParticleSystem _explosionParticle;
    
    public ExplosionEffect(float explosionRadius, float explosionForse, ParticleSystem explosionParticle)
    {
        _explosionRadius = explosionRadius;
        _explosionForse = explosionForse;
        _explosionParticle = explosionParticle;
    }

    public void Explosion(Vector3 position)
    {
        Collider[]  colliders = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IImpulseReceiver impulseReceiver = collider.gameObject.GetComponent<IImpulseReceiver>();
                    
            if (impulseReceiver != null)
                impulseReceiver.ApplyImpulse(position, _explosionForse);
        }
        
        PlayVisual(position);
    }

    private void PlayVisual(Vector3 position) => GameObject.Instantiate(_explosionParticle, position, Quaternion.identity);
}
