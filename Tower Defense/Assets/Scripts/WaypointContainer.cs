using UnityEngine;

public class WaypointContainer : MonoBehaviour
{
    public static WaypointContainer Instance;

    [SerializeField] private Transform[] _waypoints;

    public Transform[] Waypoints => _waypoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
