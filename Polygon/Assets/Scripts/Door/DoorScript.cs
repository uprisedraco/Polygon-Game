using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animation doorAnimation;

    void Awake()
    {
        doorAnimation = GetComponent<Animation>();
    }

    public void DoorAnimation()
    {
        if (doorAnimation.clip.name == "Door Up")
        {
            doorAnimation.Play();
            doorAnimation.clip = doorAnimation.GetClip("Door Down");
        }
        else
        {
            doorAnimation.Play();
            doorAnimation.clip = doorAnimation.GetClip("Door Up");
        }
    }
}
