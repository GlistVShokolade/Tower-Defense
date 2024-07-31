using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<Config, GameObject> : MonoBehaviour
{
    public static Factory<Config, GameObject> Instance;

    protected List<GameObject> _pool = new List<GameObject>();

    public IReadOnlyList<GameObject> Pool => _pool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public abstract GameObject Create(Config config);

    public virtual void Delete(GameObject gameObject)
    {
        if (_pool.Contains(gameObject) == false)
        {
            throw new KeyNotFoundException(nameof(gameObject));
        }

        _pool.Remove(gameObject);
    }
}