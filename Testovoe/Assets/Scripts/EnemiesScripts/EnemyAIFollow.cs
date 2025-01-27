using UnityEngine;
using UnityEngine.AI;

public class EnemyAIFollow : MonoBehaviour
{
    public CharacterSwap playableCharacter;
    private Transform player;
    private float distance;
    [SerializeField] private float angle;
    [SerializeField] private float followDistance;

    NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        player = playableCharacter.character;

        Vector3 dir = player.position - transform.position;
        distance = Vector3.Distance(transform.position, player.position);

        if((distance < followDistance) && (Mathf.Abs(Vector3.Angle(transform.forward, dir)) < angle))
        {
            agent.SetDestination(player.position);

        }

    }

}
