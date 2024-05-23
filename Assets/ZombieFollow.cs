using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class ZombieFollow : MonoBehaviour
// {
//     public Transform ovrCamera; // Reference to the OVR camera transform
//     public float floorLevel = 0.0f; // Y position of the floor
//     public float followSpeed = 5.0f; // Speed at which the follower moves towards the camera

//     void Update()
//     {
//         if (ovrCamera != null)
//         {
//             // Calculate the target position
//             Vector3 targetPosition = new Vector3(ovrCamera.position.x, floorLevel, ovrCamera.position.z);

//             // Move towards the target position with a speed limit
//             transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
//         }
//     }
// }

using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    public Transform ovrCamera; // Reference to the OVR camera transform
    public float floorLevel = 0.0f; // Y position of the floor
    public float followSpeed = 5.0f; // Speed at which the follower moves towards the camera
    public float maxSpeed = 10.0f; // Maximum speed of the follower
    public float slowdownFactor = 0.5f; // Factor by which the speed is reduced on collision
    public float speedRecoveryRate = 2.0f; // Rate at which the speed recovers after collision

    private bool isColliding = false; // Flag to track if the follower is colliding with an object

    void Update()
    {
        if (ovrCamera != null)
        {
            // Calculate the target position
            Vector3 targetPosition = new Vector3(ovrCamera.position.x, floorLevel, ovrCamera.position.z);

            // Calculate speed based on collision state
            float currentSpeed = isColliding ? followSpeed * slowdownFactor : followSpeed;

            // Move towards the target position with a speed limit
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

            // Gradually increase speed back to max speed if not colliding
            if (!isColliding && followSpeed < maxSpeed)
            {
                followSpeed += Time.deltaTime * speedRecoveryRate;
                followSpeed = Mathf.Min(followSpeed, maxSpeed);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reduce speed and set collision flag when collision occurs
        followSpeed *= slowdownFactor;
        isColliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset collision flag when no longer colliding
        isColliding = false;
    }
}
