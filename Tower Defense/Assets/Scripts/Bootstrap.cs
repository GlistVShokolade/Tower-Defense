using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private BuildingConfig _buildingConfig;
    [SerializeField] private EnemyConfig _enemyConfig;

    private void Start()
    {
        EnemyFactory.Instance.Get(_enemyConfig);
        BuildingFactory.Instance.Get(_buildingConfig);
    }
}
