using TMPro;
using UnityEngine;

public class HealthVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    
    private Health _health;

    public void SetHealth(Health health) => _health = health;

    private void Update() => _healthText.text = $"{_health.CurrentHealth} / {_health.MaxHealth}";
}
