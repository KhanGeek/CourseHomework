using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, ICharacterInitializable
{
    [SerializeField] private Image _healthBar;

    private IReadOnlyHealth _health;
    private Transform _cameraTransform;

    public void Initialize(Character character)
    {
        _health = character.Health;
        _cameraTransform = Camera.main.transform;

        _health.ChangeHealth += OnChangeHealth;

        OnChangeHealth(_health.MaxHealth);
    }

    private void OnDestroy() => _health.ChangeHealth -= OnChangeHealth;

    private void Update() => transform.rotation = _cameraTransform.rotation;

    private void OnChangeHealth(float currentHealth) => _healthBar.fillAmount = currentHealth / _health.MaxHealth;
}
