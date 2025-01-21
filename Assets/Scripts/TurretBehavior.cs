using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;  // Reference to the player's transform
    [SerializeField] private float turretRange = 3;

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        // Get direction vector from turret to player
        Vector2 direction = target.position - transform.position;

        // Calculate the angle between the turret and the player using Atan2 (returns angle in radians)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the turret's rotation to face the player
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        CheckRange();
    }

    public void CheckRange()
    {
        if (target == null) return;
        float distanceX = target.position.x - transform.position.x;
        float distanceY = target.position.y - transform.position.y;
        
        float distance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);

        if (distance < turretRange)
        {
            FireBullet();
            Debug.Log("In Range");
        }
    }

    public void FireBullet()
    {
        
    }

    public float Dot(Vector2 pos, Vector2 dir)
    {
        return pos.x * dir.x + pos.y * dir.y;
    }

    public float Cross(Vector2 pos, Vector2 dir)
    {
        return pos.x * dir.y - pos.y * dir.x;
    }
}