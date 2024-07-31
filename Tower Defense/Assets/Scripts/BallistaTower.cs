using UnityEngine;

public class BallistaTower : Building, IDamagable
{
    [SerializeField] private Health _health;
    [SerializeField] private TowerAttack _attack;
    [SerializeField] private TowerVision _vision;

    public void TakeDamage(int damage) => _health.TakeDamage(damage);

    private void Start()
    {
        _vision.StartResearch();
    }
}
