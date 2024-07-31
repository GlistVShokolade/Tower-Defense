using UnityEngine;

[CreateAssetMenu]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private Enemy _prefab;

    public Enemy Prefab => _prefab;
}
