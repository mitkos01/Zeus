using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);  // Включаем меню паузы
        Time.timeScale = 0f;          // Останавливаем время
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Отключаем меню паузы
        Time.timeScale = 1f;           // Возвращаем нормальную скорость времени
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Перезапускаем текущий уровень
    }

    public void LoadLevelSelection()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelector");  // Замените "LevelSelection" на имя вашей сцены с выбором уровня
    }

    public void OpenSettings()
    {
        // Логика для открытия настроек
        Debug.Log("Settings button clicked");
    }
}
