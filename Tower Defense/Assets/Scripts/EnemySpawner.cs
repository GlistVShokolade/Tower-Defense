using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(0.01f)] private float _spawnDelay;
    [Space]
    [SerializeField] private EnemyConfig _config;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_spawnDelay);
    }

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return _wait;

            EnemyFactory.Instance.Create(_config);
        }
    }
}
