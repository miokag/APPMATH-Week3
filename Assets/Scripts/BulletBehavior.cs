using UnityEngine;
using UnityEngine.SceneManagement;
public class BulletBehavior : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    private Transform playerTransform;
    private float hitThreshold = 0.5f; 

    public void Initialize(Vector2 direction, float speed)
    {
        moveDirection = direction;
        moveSpeed = speed;

        // Find the player by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Move the bullet
        transform.position += (Vector3)(moveDirection * moveSpeed * Time.deltaTime);

        // Check if bullet "hits" the player
        if (playerTransform != null && IsPlayerHit())
        {
            Debug.Log("Player hit!");
            ReloadScene();
            Destroy(gameObject); 
        }

        if (transform.position.magnitude > 5f) 
        {
            Destroy(gameObject);
        }
    }

    private bool IsPlayerHit()
    {
        float dx = transform.position.x - playerTransform.position.x;
        float dy = transform.position.y - playerTransform.position.y;
        float distanceSquared = dx * dx + dy * dy;

        return distanceSquared <= hitThreshold * hitThreshold;
    }
    
    private void ReloadScene()
    {
        // Get the current scene name and reload it
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}