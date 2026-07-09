using UnityEngine;

public class RigidbodyImpulseReceiver : MonoBehaviour, IImpulseReceiver
{
    [SerializeField] Rigidbody _rigidbody;
    
    public void ApplyImpulse(Vector3 impulseCenter, float forseImpulse)
    {
        Vector3 impulseDirection = transform.position - impulseCenter;
        _rigidbody.AddForce(impulseDirection * forseImpulse, ForceMode.Impulse);
    }
}
