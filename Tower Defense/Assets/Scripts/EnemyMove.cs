using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
    private int _currentIndex;

    private Rigidbody _rigidbody;

    private int WaypointCount => WaypointContainer.Instance.Waypoints.Length;
    private Vector3 WaypointPosition => WaypointContainer.Instance.Waypoints[_currentIndex].position;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(MoveLoop());
    }

    private IEnumerator MoveLoop()
    {
        while (true)
        {
            Vector3 direction = WaypointPosition - _rigidbody.position;

            Move(direction);

            if (Vector3.SqrMagnitude(_rigidbody.position - WaypointPosition) < 0.3f)
            {
                _currentIndex++;

                if (_currentIndex >= WaypointCount)
                {
                    _currentIndex = 0;
                }
            }

            yield return null;
        }
    }

    private void Move(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }
}
