using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 targetPosition;

    public void Initialize(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        if (targetPosition != null)
        {
            // ������� ������ � ����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // ��������� ����������� � ����
            Vector3 direction = targetPosition - transform.position;

            // ��������� ���� ��������
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ������������ ������ ���, ����� ��� �������� �������� �� ����
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // -90 ��� ��������� ����������

            // ���������� ������, ����� �� ��������� ����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ball"))
        {
            collider.gameObject.GetComponent<BallMovement>().player.GetComponent<PlayerController>().AddCoin();  // ��������� ������
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
