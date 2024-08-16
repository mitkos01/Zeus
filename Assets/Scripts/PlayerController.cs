using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health = 20;
    public Text healthText;

    void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage()
    {
        health--;
        UpdateHealthUI();

        if (health <= 0)
        {
            Debug.Log("Player is defeated!");
            
        }
    }

    void UpdateHealthUI()
    {
        healthText.text = health.ToString();
    }
}
