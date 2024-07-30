using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<Config, GameObject> : MonoBehaviour
{
    public static Factory<Config, GameObject> Instance;

    protected List<GameObject> _pool = new List<GameObject>();

    public IReadOnlyList<GameObject> Pool => _pool;

    public abstract GameObject Get(Config config);
    public abstract void Remove(GameObject gameObject);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}