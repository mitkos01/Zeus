using UnityEngine;
using UnityEngine.SceneManagement; // Для перехода между сценами
using UnityEngine.UI; // Для работы с UI элементами
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] pathPoints;
    public Transform player;
    public float spawnInterval = 1.5f;  // Интервал между спавном шариков
    public int maxBallsAtOnce = 20;     // Максимальное количество активных шариков
    public GameObject levelCompletePanel;  // Панель завершения уровня

    // Ссылки на кнопки
    public Button nextLevelButton;
    public Button levelsButton;
    public Button upgradesButton;

    private int ballsActive = 0;
    private int totalBallsSpawned = 0;  // Счётчик общего количества созданных шариков

    void Start()
    {
        if (ballPrefab == null || pathPoints.Length == 0 || player == null)
        {
            Debug.LogError("BallPrefab, path points, or player are not set");
            return;
        }

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);  // Скрыть панель завершения уровня
        }

        // Настроить кнопки
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        }
        if (levelsButton != null)
        {
            levelsButton.onClick.AddListener(OnLevelsButtonClicked);
        }
        if (upgradesButton != null)
        {
            upgradesButton.onClick.AddListener(OnUpgradesButtonClicked);
        }

        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (totalBallsSpawned < maxBallsAtOnce)
        {
            if (ballsActive < maxBallsAtOnce)
            {
                SpawnBall();
                yield return new WaitForSeconds(spawnInterval); // Интервал между спавном шариков
            }
            else
            {
                // Ждём, пока количество активных шариков уменьшится
                yield return null;
            }
        }
    }

    void SpawnBall()
    {
        Transform startPoint = pathPoints[Random.Range(0, pathPoints.Length)];
        GameObject ball = Instantiate(ballPrefab, startPoint.position, Quaternion.identity);
        BallMovement ballMovement = ball.GetComponent<BallMovement>();
        if (ballMovement == null)
        {
            Debug.LogError("BallPrefab does not have a BallMovement");
            return;
        }
        ballMovement.Initialize(pathPoints, player);
        ballsActive++;
        totalBallsSpawned++;
    }

    public void BallDestroyed()
    {
        ballsActive--;
        if (totalBallsSpawned >= maxBallsAtOnce && ballsActive <= 0)
        {
            // Игрок победил
            Debug.Log("Player wins!");
            if (levelCompletePanel != null)
            {
                levelCompletePanel.SetActive(true);  // Показать панель завершения уровня
            }
        }
    }

    void OnNextLevelButtonClicked()
    {
        // Переход на следующий уровень
        SceneManager.LoadScene("Level3");
    }

    void OnLevelsButtonClicked()
    {
        // Переход к меню выбора уровней
        SceneManager.LoadScene("LevelSelector");  // Замените на имя вашей сцены с выбором уровней
    }

    void OnUpgradesButtonClicked()
    {
        // Переход к меню улучшений
        SceneManager.LoadScene("UpgradesMenu");  // Замените на имя вашей сцены с улучшениями
    }
}
