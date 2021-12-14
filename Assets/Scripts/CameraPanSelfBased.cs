﻿using UnityEngine;

public class CameraPanSelfBased : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 100f;
    [SerializeField] float panSpeed = 100f;
    [SerializeField] float verticalMovementSpeed = 10f;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        if (Input.GetMouseButton(1))
        {

            if (mouseX != 0 && Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
            {
                transform.rotation = Quaternion.AngleAxis(mouseX * panSpeed * Time.deltaTime, Vector3.up) * transform.rotation;
            }

            if (mouseY != 0)
            {
                transform.rotation = Quaternion.AngleAxis(-mouseY * panSpeed * Time.deltaTime, transform.right) * transform.rotation;
            }
        }

        if (Input.GetMouseButton(2))
        {
            if (mouseX != 0 && Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
            {
                transform.position -= transform.right * mouseX * panSpeed * Time.deltaTime;
            }

            if (mouseY != 0)
            {
                Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
                transform.position -= forward * mouseY * panSpeed * Time.deltaTime;
            }
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.position += transform.forward * scroll * Time.deltaTime * scrollSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.y += verticalMovementSpeed * Time.deltaTime;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y -= verticalMovementSpeed * Time.deltaTime;
            transform.position = pos;
        }
    }
}