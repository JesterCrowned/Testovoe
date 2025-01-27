using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;

    public void UpdateHealthBar(float maxhealth, float currenthealth)
    {
        healthbarSprite.fillAmount = currenthealth / maxhealth;
    }
}
