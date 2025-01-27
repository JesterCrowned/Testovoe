using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : MonoBehaviour
{

    [SerializeField] private CharacterSwap playableCharacter;
    [SerializeField] private LayerMask  whatIsPlayer;
    [SerializeField] private Transform projectileSpawnPoint;
    private Transform player;

    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private GameObject projectile;
    private bool alreadyAttacked;

    [SerializeField] private float attackRange;
    private bool playerInAttackRange;

    private NavMeshAgent agent;

    private void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        player = playableCharacter.character;

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange) AttackPlayer();
    }

    private void AttackPlayer()
    {

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 18f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
