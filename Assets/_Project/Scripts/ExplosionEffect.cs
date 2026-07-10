using UnityEngine;

public class ExplosionEffect: IRaycastEffect
{
    private float _explosionRadius;
    private float _explosionForse;
    
    public ExplosionEffect(float explosionRadius, float explosionForse)
    {
        _explosionRadius = explosionRadius;
        _explosionForse = explosionForse;
    }

    public void Lounch(RaycastHit hit)
    {
        Collider[]  colliders = Physics.OverlapSphere(hit.point, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IImpulseReceiver impulseReceiver = collider.gameObject.GetComponent<IImpulseReceiver>();
                    
            if (impulseReceiver != null)
                impulseReceiver.ApplyImpulse(hit.point, _explosionForse);
        }
    }
}
