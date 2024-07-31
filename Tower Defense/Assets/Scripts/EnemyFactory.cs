public class EnemyFactory : Factory<EnemyConfig, Enemy>
{
    public override Enemy Create(EnemyConfig config)
    {
        var enemy = Instantiate(config.Prefab);

        _pool.Add(enemy);

        return enemy;
    }

    public override void Delete(Enemy gameObject)
    {
        base.Delete(gameObject);

        Destroy(gameObject.gameObject);
    }
}
