using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{
    public Text coinsText;  // Ссылка на текстовый UI элемент

    void Start()
    {
        UpdateCoinsUI();
    }

    void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            int coins = PlayerPrefs.GetInt("Coins", 0);  // Загружаем количество монет из PlayerPrefs
            coinsText.text = coins.ToString();  // Отображаем монеты в UI
        }
    }
}
