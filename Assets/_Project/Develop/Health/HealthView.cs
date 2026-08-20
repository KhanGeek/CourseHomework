using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    private IReadOnlyHealth _health;

    public void Initialize(IReadOnlyHealth health)
    {
        _health = health;

        _health.ChangeHealth += OnChangeHealth;

        OnChangeHealth(_health.MaxHealth);
    }

    private void OnDestroy() => _health.ChangeHealth -= OnChangeHealth;

    private void Update() => transform.LookAt(Camera.main.transform);

    private void OnChangeHealth(float currentHealth) => _healthBar.fillAmount = currentHealth / _health.MaxHealth;
}
