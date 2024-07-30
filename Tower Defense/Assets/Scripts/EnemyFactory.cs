using System.Collections.Generic;

public class EnemyFactory : Factory<EnemyConfig, Enemy>
{
    public override Enemy Get(EnemyConfig config)
    {
        var enemy = Instantiate(config.Prefab);

        if (enemy.TryGetComponent(out IInit initable))
        {
            initable.Init();
        }
        if (enemy.TryGetComponent(out IHealthInit healthInitable))
        {
            healthInitable.Init(config.MaxHealth);
        }

        _pool.Add(enemy);

        return enemy;
    }

    public override void Remove(Enemy gameObject)
    {
        if (_pool.Contains(gameObject) == false)
        {
            throw new KeyNotFoundException(nameof(gameObject));
        }

        _pool.Remove(gameObject);

        Destroy(gameObject.gameObject);
    }
}