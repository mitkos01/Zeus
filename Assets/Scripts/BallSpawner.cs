using UnityEngine;
using UnityEngine.SceneManagement; // ��� �������� ����� �������
using UnityEngine.UI; // ��� ������ � UI ����������
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] pathPoints;
    public Transform player;
    public float spawnInterval = 1.5f;  // �������� ����� ������� �������
    public int maxBallsAtOnce = 20;     // ������������ ���������� �������� �������
    public GameObject levelCompletePanel;  // ������ ���������� ������

    // ������ �� ������
    public Button nextLevelButton;
    public Button levelsButton;
    public Button upgradesButton;

    private int ballsActive = 0;
    private int totalBallsSpawned = 0;  // ������� ������ ���������� ��������� �������

    void Start()
    {
        if (ballPrefab == null || pathPoints.Length == 0 || player == null)
        {
            Debug.LogError("BallPrefab, path points, or player are not set");
            return;
        }

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);  // ������ ������ ���������� ������
        }

        // ��������� ������
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
                yield return new WaitForSeconds(spawnInterval); // �������� ����� ������� �������
            }
            else
            {
                // ���, ���� ���������� �������� ������� ����������
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
            // ����� �������
            Debug.Log("Player wins!");
            if (levelCompletePanel != null)
            {
                levelCompletePanel.SetActive(true);  // �������� ������ ���������� ������
            }
        }
    }

    void OnNextLevelButtonClicked()
    {
        // ������� �� ��������� �������
        SceneManager.LoadScene("Level3");
    }

    void OnLevelsButtonClicked()
    {
        // ������� � ���� ������ �������
        SceneManager.LoadScene("LevelSelector");  // �������� �� ��� ����� ����� � ������� �������
    }

    void OnUpgradesButtonClicked()
    {
        // ������� � ���� ���������
        SceneManager.LoadScene("UpgradesMenu");  // �������� �� ��� ����� ����� � �����������
    }
}
