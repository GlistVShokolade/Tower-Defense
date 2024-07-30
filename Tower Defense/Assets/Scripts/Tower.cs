using UnityEngine;

public class HealthBuilding : Building, IInit, IHealthInit
{
    public Health Health { get; private set; }

    public void Init(float maxHealth)
    {
        Health = new Health(maxHealth);
    }

    public virtual void Init()
    {
        Debug.Log("Башня почти инициализирована");
    }
}

public interface IHealthInit
{
    public void Init(float maxHealth);
}