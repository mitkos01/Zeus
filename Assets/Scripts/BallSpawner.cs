using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] pathPoints;
    public Transform player;
    public float spawnInterval = 10f; 
    public int ballsPerWave = 10; 
    public int maxBallsAtOnce = 20; 
    public Text timerText; 
    private int ballsActive = 0;
    private float countdown;

    void Start()
    {
        if (ballPrefab == null || pathPoints.Length == 0 || timerText == null || player == null)
        {
            Debug.LogError("BallPrefab path points timerText player are not set");
            return;
        }

        countdown = spawnInterval;
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            timerText.text = "Next wave in: " + Mathf.Ceil(countdown).ToString() + "s";
        }
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(countdown);
            countdown = spawnInterval;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        int ballsToSpawn = Mathf.Min(ballsPerWave, maxBallsAtOnce - ballsActive);
        for (int i = 0; i < ballsToSpawn; i++)
        {
            if (ballsActive < maxBallsAtOnce)
            {
                SpawnBall();
                yield return new WaitForSeconds(0.5f);
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
    }

    public void BallDestroyed()
    {
        ballsActive--;
    }
}
