using System;
using System.Collections;
using UnityEngine;

public class TowerVision
{
    private readonly Transform _towerTransform;

    private readonly float _viewDistance;

    public event Action<IDamagable> EnemyDetected;
    public event Action EnemyLosted;

    private readonly WaitForSeconds _wait;

    public Vector3 TowerPosition => _towerTransform.position;

    public TowerVision(float viewDistance, float researchSpeed, Transform towerTransform)
    {
        _viewDistance = viewDistance >= 0f ? viewDistance : throw new ArgumentOutOfRangeException(nameof(viewDistance));

        _towerTransform = towerTransform ?? throw new NullReferenceException(nameof(towerTransform));

        _wait = new WaitForSeconds(researchSpeed);
    }

    public IEnumerator SearchLoop()
    {
        while (true)
        {
            SearchTarget();

            yield return _wait;
        }
    }

    private void SearchTarget()
    {
        foreach (var enemy in EnemyFactory.Instance.Pool)
        {
            var enemyPosition = enemy.transform.position;
            var distance = Vector3.SqrMagnitude(enemyPosition - TowerPosition);

            if (distance > _viewDistance)
            {
                continue;
            }
            if (enemy.TryGetComponent(out IDamagable damagable) == false)
            {
                continue;
            }

            EnemyLosted?.Invoke();
            EnemyDetected?.Invoke(damagable);
        }
    }
}
