using UnityEngine;

public class TowerDispose : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private GameObject _model;
    [SerializeField] private ParticleSystem _particle;

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
        _particle.Play();

        Destroy(_particle.gameObject, _particle.main.duration);
        Destroy(_model);
    }
}
