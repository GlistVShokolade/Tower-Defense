using System;
using UnityEngine;

public class BuildingMap
{
    private readonly CellState[,] _map;

    public BuildingMap(Vector2Int size) 
    {
        if (size.x <= 0 || size.y <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size));
        }

        _map = new CellState[size.x, size.y];
    }

    public bool Get(Vector2Int position)
    {
        if (position.x > 0 && position.x < _map.GetLength(0) &&
            position.y > 0 && position.y < _map.GetLength(1))
        {
            return _map[position.x, position.y] == CellState.Fulled;
        }

        return false;
    }

    public void Set(Vector2Int position, CellState state)
    {
        if (_map[position.x, position.y] == state)
            return;

        _map[position.x, position.y] = state;
    }

    public void Remove(Vector2Int position)
    {
        _map[position.x, position.y] = CellState.Empty;
    }
}
