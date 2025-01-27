using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private CharacterSwap characterSwap;
    [SerializeField] private int savedCharactres;

    [SerializeField] private Player1Health player1Health;
    [SerializeField] private Player2Health player2Health;
    [SerializeField] private Player3Health player3Health;

    [SerializeField] private GameObject winMenu;

    private void Start()
    {
        savedCharactres = 0;
        winMenu.SetActive(false);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player 1")
        {
            characterSwap.FinishSwap();
            savedCharactres += 1;
            player1Health.Death();
            if (savedCharactres == 3)
            {
                winMenu.SetActive(false);
                Invoke(nameof(ResetGame), 1f);
            }
            
        }
        if (other.gameObject.tag == "Player 2")
        {
            characterSwap.FinishSwap();
            savedCharactres += 1;
            player2Health.Death();
            if (savedCharactres == 3)
            {
                winMenu.SetActive(true);
                Invoke(nameof(ResetGame), 1f);
            }
        }
        if (other.gameObject.tag == "Player 3")
        {
            characterSwap.FinishSwap();
            savedCharactres += 1;
            player3Health.Death();
            if (savedCharactres == 3)
            {
                winMenu.SetActive(true);
                Invoke(nameof(ResetGame), 1f);
            }
        }
    }

}
