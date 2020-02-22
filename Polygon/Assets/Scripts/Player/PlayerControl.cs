using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private PlayerAnimations animations;
    private bool alive;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animations = GetComponent<PlayerAnimations>();
        alive = true;
    }

    void Update()
    {
        if (alive)
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
            animations.PlayerMove();
        }
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool point = Physics.Raycast(ray, out hit);

        if (point)
        {
            navAgent.destination = hit.point;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (alive)
        {
            if (other.gameObject.tag == "Sword")
            {
                animations.PlayerDead();
                alive = false;
                StartCoroutine(Dead());
            }
        } 
    }

    IEnumerator Dead()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
