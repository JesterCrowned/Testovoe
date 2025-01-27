using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Player1Health player1Health;
    [SerializeField] private Player2Health player2Health;
    [SerializeField] private Player3Health player3Health;
    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player 1")
        {
            player1Health.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player 2")
        {
            player2Health.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player 3")
        {
            player3Health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
