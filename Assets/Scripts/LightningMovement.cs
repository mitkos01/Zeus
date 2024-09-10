using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    public float speed = 10f;

    public void Initialize(Vector3 startPosition, Vector3 endPosition)
    {
        transform.position = startPosition;
        targetPosition = endPosition;
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<BallMovement>().player.GetComponent<PlayerController>().AddCoin();  // Начисляем монету
            Destroy(collision.gameObject);  // Уничтожаем шарик
        }
    }
}
