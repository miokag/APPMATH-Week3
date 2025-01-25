using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float turretRange = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float fireInterval = 1f;

    private float fireTimer = 0f; 

    void Update()
    {
        if (target == null) return;

        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        fireTimer += Time.deltaTime;
        CheckRange();
    }

    public void CheckRange()
    {
        if (target == null) return;

        float distanceX = target.position.x - transform.position.x;
        float distanceY = target.position.y - transform.position.y;
        float distance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);

        if (distance < turretRange && fireTimer >= fireInterval)
        {
            FireBullet();
            fireTimer = 0f;
        }
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (target.position - transform.position).normalized;

        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        if (bulletBehavior != null)
        {
            bulletBehavior.Initialize(direction, bulletSpeed);
        }
    }
}
