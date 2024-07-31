using UnityEngine;

public class ExampleEnemy : Enemy, IDamagable
{
    [SerializeField] private Health _health;

    public void TakeDamage(int damage)
    {
        Debug.Log("Враг получил урон");
        _health.TakeDamage(damage);
    }
}