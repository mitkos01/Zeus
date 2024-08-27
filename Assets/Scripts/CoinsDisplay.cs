using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{
    public Text coinsText;  // ������ �� ��������� UI �������

    void Start()
    {
        UpdateCoinsUI();
    }

    void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            int coins = PlayerPrefs.GetInt("Coins", 0);  // ��������� ���������� ����� �� PlayerPrefs
            coinsText.text = coins.ToString();  // ���������� ������ � UI
        }
    }
}
