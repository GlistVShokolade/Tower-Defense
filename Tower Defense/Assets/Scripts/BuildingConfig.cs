using System;
using UnityEngine;

[CreateAssetMenu]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [Space]
    [SerializeField] private Building _prefab;
    [SerializeField] private Vector2Int _size;

    public float MaxHealth => _maxHealth;
    public Vector2Int Size => _size;
    public Building Prefab => _prefab;
}

public class TowerConfig : BuildingConfig
{

}
