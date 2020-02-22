using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
    private NavMeshAgent navAgent;
    Animator playerAnimator;


    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<Animator>();
    }

    public void PlayerMove()
    {
        Vector3 velocity = navAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        playerAnimator.SetFloat("playerSpeed", speed);
    }

    public void PlayerDead()
    {
        playerAnimator.SetTrigger("playerDead");
    }
}
