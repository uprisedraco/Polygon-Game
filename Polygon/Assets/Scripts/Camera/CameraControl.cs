using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private float border = 25f;

    [SerializeField]
    private float rotationAngle = 100f;

    [SerializeField]
    private float zoomSpeed = 2.5f;

    [SerializeField]
    private float maxZoom = -4f;

    [SerializeField]
    private float minZoom = -10f;

    [SerializeField]
    private Vector3 offset = new Vector3(0f, 1.5f, -7f);

    [SerializeField]
    private float minAngle = 15f;

    [SerializeField]
    private float maxAngle = 70f;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if(target != null)
        {
            CameraFollow();
            CameraZoom();
            CameraRotate();
        }
    }

    private void CameraFollow()
    {
        transform.position = transform.rotation * offset + target.position;
    }

    private void CameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if(offset.z <= maxZoom && offset.z >= minZoom)
                offset.z += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        }

        if(offset.z > maxZoom)
        {
            offset.z = maxZoom;
        }
        if (offset.z < minZoom)
        {
            offset.z = minZoom;
        }
    }

    private void CameraRotate()
    {
        if (Input.mousePosition.y >= Screen.height - border)
        {
            if(transform.rotation.eulerAngles.x > minAngle)
                transform.RotateAround(target.position, -transform.right, rotationAngle * Time.deltaTime);
        }

        if (Input.mousePosition.y <= border)
        {
            if (transform.rotation.eulerAngles.x < maxAngle)
                transform.RotateAround(target.position, transform.right, rotationAngle * Time.deltaTime);
        }

        if (Input.mousePosition.x >= Screen.width - border)
        {
            transform.RotateAround(target.position, Vector3.up, rotationAngle * Time.deltaTime);
        }

        if (Input.mousePosition.x <= border)
        {
            transform.RotateAround(target.position, -Vector3.up, rotationAngle * Time.deltaTime);
        }
    }
}
