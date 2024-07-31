using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnemyConfig _config;

    private void Start()
    {
        EnemyFactory.Instance.Create(_config);
    }
}
