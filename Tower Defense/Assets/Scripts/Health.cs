using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;
    public event Action HealthOver;

    [SerializeField, Min(0)] private int _maxHealth;
    [SerializeField, Min(0)] private int _startHealth;

    private int _currentHealth;

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        private set
        {
            _currentHealth = Math.Clamp(value, 0, _maxHealth);
        }
    }

    public int MaxHealth => _maxHealth;

    private void Start()
    {
        CurrentHealth = _startHealth;

        HealthChanged?.Invoke();

        if (CurrentHealth == 0f)
        {
            HealthOver?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        CurrentHealth -= damage;

        HealthChanged?.Invoke();

        if (CurrentHealth == 0f)
        {
            HealthOver?.Invoke();
        }
    }

    public void ApplyHealth(int health)
    {
        if (health < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(health));
        }

        CurrentHealth += health;

        HealthChanged?.Invoke();
    }
}
