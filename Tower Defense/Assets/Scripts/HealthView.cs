using System;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    private Health _health;

    public void Initialize(Health health)
    {
        _health = health ?? throw new NullReferenceException(nameof(health));
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateValue;
    }

    protected abstract void UpdateValue();
}
