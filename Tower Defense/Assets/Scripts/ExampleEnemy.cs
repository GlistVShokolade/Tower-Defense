using UnityEngine;

public class ExampleEnemy : HealthEnemy, IDamagable
{
    public void ApplyDamage(float damage)
    {
        Debug.Log("Я маслину поймал!");
    }

    public override void Init()
    {
        base.Init();

        Debug.Log("Инициализация врага окончина!");
    }
}
