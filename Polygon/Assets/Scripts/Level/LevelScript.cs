using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelScript : MonoBehaviour
{
    private Animation levelAnimation;

    [SerializeField]
    private DoorScript door;

    private Transform player;

    [SerializeField]
    private float distance = 1f;

    void Awake()
    {
        levelAnimation = GetComponent<Animation>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnMouseDown()
    {
        if(Vector3.Distance(player.position, transform.position) <= distance)
        {
            if (levelAnimation.clip.name == "Level Up")
            {
                levelAnimation.Play();
                levelAnimation.clip = levelAnimation.GetClip("Level Down");
                door.DoorAnimation();

            }
            else
            {
                levelAnimation.Play();
                levelAnimation.clip = levelAnimation.GetClip("Level Up");
                door.DoorAnimation();
            }
        }
    }
}
