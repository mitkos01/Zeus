using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
