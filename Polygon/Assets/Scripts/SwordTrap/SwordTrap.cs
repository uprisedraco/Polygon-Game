using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrap : MonoBehaviour
{
    [SerializeField]
    GameObject sword;

    GameObject[] swordSpawner;
    bool spawn;

    void Awake()
    {
        swordSpawner = GameObject.FindGameObjectsWithTag("Spawner");
        spawn = true;
    }

    private void LateUpdate()
    {
        if (spawn)
        {
            StartCoroutine(SpawnSword());
        }
    }

    IEnumerator SpawnSword()
    {
        spawn = false;
        yield return new WaitForSecondsRealtime(3);
        foreach(GameObject point in swordSpawner)
        {
            Instantiate(sword, point.transform);
        }
        spawn = true;
    }
}
