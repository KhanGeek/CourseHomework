using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect: IRaycastEffect
{
    public void Lounch(RaycastHit hit)
    {
        Collider[]  colliders = Physics.OverlapSphere(hit.point, 4f);

        foreach (Collider collider in colliders)
        {
            IImpulseReceiver impulseReceiver = collider.gameObject.GetComponent<IImpulseReceiver>();
                    
            if (impulseReceiver != null)
                impulseReceiver.ApplyImpulse(hit.point, 10);
        }
    }
}
