using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fellow : MonoBehaviour
{
    public Transform target; // Reference to the XR Rig's Camera
    public float followSpeed = 1.0f; // Speed at which the object follows the camera

    void Update()
    {
        if (target != null)
        {
            // Calculate the target position and rotation
            Vector3 targetPosition = target.position;
            Quaternion targetRotation = target.rotation;

            // Debug logs for debugging
            Debug.Log("Target Position: " + targetPosition);
            Debug.Log("Target Rotation: " + targetRotation.eulerAngles);

            // Move towards the target position with a speed limit
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Rotate towards the target rotation with a speed limit
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target not assigned in Fellow script!");
        }
    }
}

