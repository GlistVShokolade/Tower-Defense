public class BuildingFactory : Factory<BuildingConfig, Building>
{
    public override Building Create(BuildingConfig config)
    {
        var building = Instantiate(config.Prefab);

        _pool.Add(building);

        return building;
    }

    public override void Delete(Building gameObject)
    {
        base.Delete(gameObject);

        Destroy(gameObject.gameObject);
    }
}
