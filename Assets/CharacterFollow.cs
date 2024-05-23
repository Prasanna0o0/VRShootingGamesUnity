using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform target; // Reference to the OVR camera's transform
    public float followSpeed = 1.0f; // Speed at which the character follows the camera
    private Animator animator; // Reference to the character's animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the animator component
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the target position and rotation
            Vector3 targetPosition = target.position;
            Quaternion targetRotation = target.rotation;

            // Move towards the target position with a speed limit
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Rotate towards the target rotation with a speed limit
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, followSpeed * Time.deltaTime);

            // Set movement speed in animator
            Vector3 velocity = (targetPosition - transform.position) / Time.deltaTime;
            float speed = Mathf.Clamp01(velocity.magnitude / followSpeed);
            animator.SetFloat("Speed", speed);
        }
        else
        {
            Debug.LogWarning("Target not assigned in CharacterFollow script!");
        }
    }
}
