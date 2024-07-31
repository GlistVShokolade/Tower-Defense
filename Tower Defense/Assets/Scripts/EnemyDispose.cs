using UnityEngine;

public class EnemyDispose : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private GameObject _model;

    private void OnEnable()
    {
        _health.HealthOver += Dispose;
    }

    private void OnDisable()
    {
        _health.HealthOver -= Dispose;
    }

    private void Dispose()
    {
        Debug.Log("Враг был убит башней");
        EnemyFactory.Instance.Delete(_enemy);
        Destroy(_model);
    }
}
