using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float force = 10000;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.AddForce(Vector3.left * force * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 1f);
    }
}
