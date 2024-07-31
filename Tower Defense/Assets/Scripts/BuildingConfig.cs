using UnityEngine;

[CreateAssetMenu]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private Building _prefab;

    public Building Prefab => _prefab;
}
