using UnityEngine;

public class Health
{
    private float _currentHealth;
    private float _maxHealth;

    private float _percentageBeforeInjury;

    public Health(float maxHealth, float percentageBeforeInjury)
    {
        _maxHealth = maxHealth;
        _percentageBeforeInjury = percentageBeforeInjury;
        
        _currentHealth = _maxHealth;
    }
    
    public float CurrentHealth => _currentHealth;
    
    public float MaxHealth => _maxHealth;

    public bool IsWounded => _currentHealth / _maxHealth < _percentageBeforeInjury;
    
    public bool IsDead => _currentHealth <= 0;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Damage is less than 0");
            return;
        }
        
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
            _currentHealth = 0;
    }
}
