using UnityEngine;

public class EnemyFollowCamera : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Transform cameraTransform; // Reference to the XR Rig's Camera
    public float followSpeed = 1.0f; // Speed at which the enemy follows the camera
    public float distance = 2.0f; // Distance between the enemy and the camera
    public float detectionRadius = 5.0f; // Radius within which the enemy detects the player

    private bool isChasing = false; // Flag to indicate if the enemy is chasing the player

    void Update()
    {
        if (cameraTransform != null)
        {
            // Calculate the target position with an offset
            Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * distance;

            if (playerTransform != null && !isChasing)
            {
                // Check if the player is within the detection radius
                if (Vector3.Distance(transform.position, playerTransform.position) <= detectionRadius)
                {
                    isChasing = true;
                }
            }

            if (isChasing)
            {
                // Move the enemy towards the player
                if (playerTransform != null)
                {
                    targetPosition = playerTransform.position;
                }
            }

            // Move the enemy towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Ensure the enemy faces towards the camera or the player
            transform.LookAt(isChasing ? playerTransform.position : cameraTransform.position);
        }
        else
        {
            Debug.LogWarning("Camera transform not assigned in EnemyFollowCamera script!");
        }
    }
}
