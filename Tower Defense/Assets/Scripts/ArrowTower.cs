using System.Collections;
using UnityEngine;

public class ArrowTower : HealthBuilding
{
    private TowerVision _vision;
    private TowerAttack _attack;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [Space]
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _researchTargetTime;

    public override void Init()
    {
        base.Init(); 

        _vision = new TowerVision(_viewDistance, _researchTargetTime, transform);
        _attack = new TowerAttack(this, _vision, _damage, _attackSpeed);

        StartCoroutine(_vision.SearchLoop());

        Debug.Log("Башня окончательно инициализирована");
    }
}
