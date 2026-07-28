using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _healAmount;
    
    private void OnTriggerEnter(Collider other)
    {
        ITreatable treatable = other.GetComponent<ITreatable>();

        if (treatable == null)
            return;

        treatable.Heal(_healAmount);
        
        Destroy(gameObject);
    }
}
