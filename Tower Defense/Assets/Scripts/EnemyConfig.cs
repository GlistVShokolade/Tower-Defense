using UnityEngine;

[CreateAssetMenu]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [Space]
    [SerializeField] private Enemy _prefab;

    public float MaxHealth => _maxHealth;

    public Enemy Prefab => _prefab;
}
