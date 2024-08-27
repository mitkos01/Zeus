using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);  // Загружаем сцену по переданному имени
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");  // Возвращаемся в главное меню
    }
}
