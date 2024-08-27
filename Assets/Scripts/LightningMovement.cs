using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    private Vector3 intermediatePosition;
    private Vector3 lightningRodPosition;
    public float speed = 10f;
    private int state = 0;

    public void Initialize(Vector3 startPosition, Vector3 intermediatePos, Vector3 endPosition)
    {
        transform.position = startPosition;
        intermediatePosition = intermediatePos;
        lightningRodPosition = endPosition;
    }

    void Update()
    {
        if (state == 0)
        {
            MoveToIntermediate();
        }
        else if (state == 1)
        {
            MoveToLightningRod();
        }
    }

    void MoveToIntermediate()
    {
        transform.position = Vector3.MoveTowards(transform.position, intermediatePosition, speed * Time.deltaTime);
        if (transform.position == intermediatePosition)
        {
            state = 1;
        }
    }

    void MoveToLightningRod()
    {
        transform.position = Vector3.MoveTowards(transform.position, lightningRodPosition, speed * Time.deltaTime);
        if (transform.position == lightningRodPosition)
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
