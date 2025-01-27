using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private GameObject gameOverMenu;

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if(health <= 0)
        {
            Death();
            gameOverMenu.SetActive(true);
            Invoke(nameof(ResetGame), 0.5f);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.UpdateHealthBar(maxHealth, health);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health -= 1;
            healthBar.UpdateHealthBar(maxHealth, health);
        }

    }

    public void Death()
    {
        this.gameObject.SetActive(false);

    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
