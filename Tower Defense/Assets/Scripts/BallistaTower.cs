using UnityEngine;

public class BallistaTower : Building, IDamagable
{
    [SerializeField] private Health _health;

    public void TakeDamage(int damage) => _health.TakeDamage(damage);
}
