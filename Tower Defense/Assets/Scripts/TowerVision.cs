using System;
using System.Collections;
using UnityEngine;

public class TowerVision : MonoBehaviour
{
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    [SerializeField] private Transform _viewpoint;
    [Space]
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _researchTime;

    public Vector3 ViewpointPosition => _viewpoint.position;

    public event Action<IDamagable> TargetDetected;

    private void Awake()
    {
        _wait = new WaitForSeconds(_researchTime);
    }

    private void Start()
    {
        StartResearch();
    }

    public void StartResearch()
    {
        _coroutine = StartCoroutine(ResearchLoop());
    }
    public void StopResearch()
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(ResearchLoop());
    }

    private IEnumerator ResearchLoop()
    {
        while (true)
        {
            SearchTarget();

            yield return _wait;
        }
    }

    private void SearchTarget()
    {
        foreach (var target in EnemyFactory.Instance.Pool)
        {
            var enemyPosition = target.transform.position;
            var distance = Vector3.Distance(ViewpointPosition, enemyPosition);

            if (distance > _viewDistance)
            {
                continue;
            }
            if (target.TryGetComponent(out IDamagable damagable) == false)
            {
                continue;
            }

            TargetDetected?.Invoke(damagable);

            Debug.Log("Враг был найден! Событие было вызвано!");
        }
    }
}
