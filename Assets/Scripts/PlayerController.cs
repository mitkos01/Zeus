using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 20;
    public Text healthText;
    public GameObject gameOverCanvas;
    private int coinCount = 0;
    public Text coinText;  // Ссылка на текст UI для отображения монет

    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins", 0);  // Загружаем количество монет из PlayerPrefs
        UpdateHealthUI();
        UpdateCoinUI();
        gameOverCanvas.SetActive(false);
    }

    public void TakeDamage()
    {
        health--;
        UpdateHealthUI();

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();
        PlayerPrefs.SetInt("Coins", coinCount);  // Сохраняем количество монет в PlayerPrefs
    }

    void UpdateHealthUI()
    {
        healthText.text = health.ToString();
    }

    void UpdateCoinUI()
    {
        coinText.text = coinCount.ToString();
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevelSelection()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }
}
