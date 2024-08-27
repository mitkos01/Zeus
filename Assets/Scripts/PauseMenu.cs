using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);  // �������� ���� �����
        Time.timeScale = 0f;          // ������������� �����
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // ��������� ���� �����
        Time.timeScale = 1f;           // ���������� ���������� �������� �������
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // ������������� ������� �������
    }

    public void LoadLevelSelection()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelector");  // �������� "LevelSelection" �� ��� ����� ����� � ������� ������
    }

    public void OpenSettings()
    {
        // ������ ��� �������� ��������
        Debug.Log("Settings button clicked");
    }
}
