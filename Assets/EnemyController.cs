using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check distance to player
        // If within attack range
        animator.SetBool("isAttacking", true);
        // Else
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
        // Move towards player
    }
}


