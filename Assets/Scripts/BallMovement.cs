using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Transform[] pathPoints;
    public Transform player;
    public float speed = 5f;
    private int currentPointIndex = 0;
    private BallSpawner ballSpawner;

    public void Initialize(Transform[] points, Transform playerTransform)
    {
        pathPoints = points;
        player = playerTransform;
        transform.position = pathPoints[currentPointIndex].position;
    }

    void Start()
    {
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Vector3 targetPosition;

        if (currentPointIndex < pathPoints.Length)
        {
            targetPosition = pathPoints[currentPointIndex].position;
        }
        else
        {
            targetPosition = player.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (currentPointIndex < pathPoints.Length)
            {
                currentPointIndex++;
            }
            else
            {
                player.GetComponent<PlayerController>().TakeDamage();  // Уменьшаем здоровье игрока
                Destroy(gameObject);
            }
        }
    }

    void OnDestroy()
    {
        if (ballSpawner != null)
        {
            ballSpawner.BallDestroyed();  // Уведомляем BallSpawner об уничтожении шарика
        }
    }
}
