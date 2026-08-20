using System;

public class Health : IReadOnlyHealth
{
    public event Action<float> ChangeHealth;
    public event Action Death;

    private float _currentHealth;
    private float _maxHealth;

    public Health(float maxHealth) => _maxHealth = maxHealth;

    public float MaxHealth => _maxHealth;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException($" {nameof(damage)} cannot be less than 0");

        _currentHealth -= damage;
        ChangeHealth?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Death?.Invoke();
    }
}
