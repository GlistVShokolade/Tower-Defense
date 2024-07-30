using System.Collections.Generic;

public class BuildingFactory : Factory<BuildingConfig, Building>
{
    public override Building Get(BuildingConfig config)
    {
        var building = Instantiate(config.Prefab);

        if (building.TryGetComponent(out IInit initable))
        {
            initable.Init();
        }
        if (building.TryGetComponent(out IHealthInit healthInitable))
        {
            healthInitable.Init(config.MaxHealth);
        }

        _pool.Add(building);

        return building;
    }

    public override void Remove(Building gameObject)
    {
        if (_pool.Contains(gameObject) == false)
        {
            throw new KeyNotFoundException(nameof(gameObject));
        }

        _pool.Remove(gameObject);

        Destroy(gameObject.gameObject);
    }
}
