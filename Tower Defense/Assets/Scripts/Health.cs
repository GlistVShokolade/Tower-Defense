using System;

public sealed class Health
{
    private float _currentHealth;
    private readonly float _maxHealth;

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        private set
        {
            _currentHealth = Math.Clamp(value, 0f, _maxHealth);
        }
    }

    public event Action HealthChanged;
    public event Action HealthOver;

    public Health(float maxHealth)
    {
        if (maxHealth < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(maxHealth));
        }

        _maxHealth = maxHealth;
        _currentHealth = maxHealth;

        HealthChanged?.Invoke();
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        CurrentHealth -= damage;

        HealthChanged?.Invoke();

        if (_currentHealth == 0f)
        {
            HealthOver?.Invoke();
        }
    }

    public void AddHealth(float amount)
    {
        if (amount < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentHealth += amount;

        HealthChanged?.Invoke();
    }
}
