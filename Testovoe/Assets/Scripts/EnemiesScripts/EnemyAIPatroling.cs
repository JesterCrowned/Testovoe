using UnityEngine;
using UnityEngine.AI;

public class EnemyAIPatroling : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex;
    Vector3 target;

    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target)<1)
        {
            IncreseWaypointIndex();
            UpdateDestination();
        }
    }

    private void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    private void IncreseWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

    }
}
