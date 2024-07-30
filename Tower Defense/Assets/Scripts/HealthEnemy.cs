using UnityEngine;

public class HealthEnemy : Enemy, IInit
{
    public Health Health { get; private set; }

    public virtual void Init()
    {
        Debug.Log("Начало инициализации врага!");
    }
}