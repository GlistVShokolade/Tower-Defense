using System;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    private BuildingMap _map;

    public void Initialize(BuildingMap map)
    {
        _map = map ?? throw new NullReferenceException(nameof(map));
    }

    private bool TrySet(Vector2Int position, CellState state)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Set(position, state);

            return true;
        }

        return false;
    }

    private bool TryRemove(Vector2Int position)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Remove(position);

            return true;
        }

        return false;
    }

    private void Set(Vector2Int position, CellState state)
    {
        _map.Set(position, state);
    }

    private void Remove(Vector2Int position)
    {
        _map.Remove(position);
    }
}
