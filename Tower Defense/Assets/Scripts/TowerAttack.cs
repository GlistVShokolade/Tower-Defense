using System;
using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class TowerAttack : IDisposable, IInit
{
    private readonly float _damage;

    private readonly TowerVision _vision;
    private readonly MonoBehaviour _context;
    private readonly WaitForSeconds _wait;

    public event Action AttackPerformed;

    public TowerAttack(MonoBehaviour context, TowerVision vision, float damage, float speed)
    {
        _damage = damage >= 0f ? damage : throw new ArgumentOutOfRangeException(nameof(damage));

        _vision = vision ?? throw new NullReferenceException(nameof(vision));
        _context = context ?? throw new NullReferenceException(nameof(context));

        _wait = new WaitForSeconds(speed);

        Init();
    }

    public IEnumerator AttackLoop(IDamagable target)
    {
        while (true)
        {
            Attack(target);

            yield return _wait;
        }
    }

    private void StartAttack(IDamagable target) => _context.StartCoroutine(AttackLoop(target));

    private void StopAttack() => _context.StopCoroutine(AttackLoop(null));

    private void Attack(IDamagable damagable)
    {
        Debug.Log("Атака совершенна");

        damagable.ApplyDamage(_damage);
    }

    public void Dispose()
    {
        _vision.EnemyDetected -= StartAttack;
        _vision.EnemyLosted -= StopAttack;
    }

    public void Init()
    {
        _vision.EnemyDetected += StartAttack;
        _vision.EnemyLosted += StopAttack;
    }
}
