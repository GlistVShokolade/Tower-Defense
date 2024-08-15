using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private int _currentIndex;

    private NavMeshAgent _agent;

    private int WaypointCount => WaypointContainer.Instance.Waypoints.Length;
    private Vector3 WaypointPosition => WaypointContainer.Instance.Waypoints[_currentIndex].position;
    private Vector3 AgentPosition => _agent.transform.position;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(MoveLoop());
    }

    private IEnumerator MoveLoop()
    {
        while (true)
        {
            Move(WaypointPosition);

            if (Vector3.SqrMagnitude(AgentPosition - WaypointPosition) < _agent.stoppingDistance)
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

    private void Move(Vector3 target)
    {
        _agent.SetDestination(target);
    }
}
