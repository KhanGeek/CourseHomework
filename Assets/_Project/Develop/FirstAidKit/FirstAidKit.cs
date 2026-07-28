using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _healAmount;
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageble damageble = other.GetComponent<IDamageble>();

        if (damageble == null)
            return;

        damageble.Heal(_healAmount);
        
        Destroy(gameObject);
    }
}
