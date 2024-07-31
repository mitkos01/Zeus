using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    void Update()
    {
        
        GameObject ball = FindClosestBall();
        if (ball != null && Time.time > nextFireTime)
        {
            ShootAtBall(ball.transform);
            nextFireTime = Time.time + fireRate;
        }
    }

    GameObject FindClosestBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject closestBall = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject ball in balls)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestBall = ball;
            }
        }
        return closestBall;
    }

    void ShootAtBall(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
        projectile.GetComponent<Projectile>().Initialize(target.position);
    }
}
