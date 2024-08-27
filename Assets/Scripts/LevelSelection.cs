using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);  // ��������� ����� �� ����������� �����
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");  // ������������ � ������� ����
    }
}
