using System.Collections;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    [SerializeField] private TowerVision _vision;
    [Space]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _wait = new WaitForSeconds(_speed);
    }

    private void OnEnable()
    {
        _vision.TargetDetected += StopAttack;
        _vision.TargetDetected += StartAttack;
    }

    private void OnDisable()
    {
        _vision.TargetDetected -= StopAttack;
        _vision.TargetDetected -= StartAttack;
    }

    public void StartAttack(IDamagable damagable)
    {
        _coroutine = StartCoroutine(AttackLoop(damagable));
    }

    public void StopAttack(IDamagable damagable)
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(_coroutine);
    }

    private IEnumerator AttackLoop(IDamagable damagable)
    {
        while (true)
        {
            yield return _wait;
             
            Attack(damagable);
        }
    }

    private void Attack(IDamagable damagable) => damagable.TakeDamage(_damage);
}
