using UnityEngine;

public class CameraPanSelfBased : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 100f;
    [SerializeField] float panSpeed = 10f;
    [SerializeField] float rotateSpeed = 100f;
    // [SerializeField] float verticalMovementSpeed = 10f;
    // [SerializeField] float horizontalMovementSpeed = 10f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        if (Input.GetMouseButton(1))
        {

            if (mouseX != 0 && Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
            {
                transform.rotation = Quaternion.AngleAxis(mouseX * rotateSpeed * Time.deltaTime, Vector3.up) * transform.rotation;
            }

            if (mouseY != 0)
            {
                transform.rotation = Quaternion.AngleAxis(-mouseY * rotateSpeed * Time.deltaTime, transform.right) * transform.rotation;
            }
        }

        if (Input.GetMouseButton(2))
        {
            if (Mathf.Abs(mouseY) > 0.1f)
            {
                Vector3 pos = transform.position;
                pos.y -= mouseY * panSpeed * Time.deltaTime;
                transform.position = pos;
            }
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.position += transform.forward * scroll * Time.deltaTime * scrollSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
            transform.position += forward * panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
            transform.position -= forward * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * panSpeed * Time.deltaTime;
        }
    }
}
