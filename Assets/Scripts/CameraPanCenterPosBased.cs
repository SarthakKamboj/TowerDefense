using UnityEngine;
using Cinemachine;

public class CameraPanCenterPosBased : MonoBehaviour
{

    [SerializeField] Transform cameraCenter;
    [SerializeField] float cameraPanSpeed = 2f;
    [SerializeField] float zoomIntensity = 5f;

    float radius;
    float angle;
    Vector3 runningOffset;
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;

        UpdateOffsetAndRadius();
        UpdateAngle();
    }

    void Update()
    {

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        Vector3 forward = Vector3.ProjectOnPlane(cam.forward, Vector3.up);
        if (Input.GetMouseButton(1))
        {

            if (mouseY != 0 && Mathf.Abs(mouseY) > Mathf.Abs(mouseX))
            {
                cameraCenter.position += forward * mouseY * cameraPanSpeed;

                UpdateOffsetAndRadius();
                UpdateAngle();

                cam.transform.rotation = Quaternion.LookRotation(-runningOffset.normalized, Vector3.up);
            }
            else if (mouseX != 0)
            {
                angle -= mouseX;
                UpdatePos();
                cam.rotation = Quaternion.LookRotation(-runningOffset.normalized, Vector3.up);
            }
        }
        else if (Input.GetMouseButton(2))
        {
            if (mouseX != 0 && Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
            {
                cameraCenter.position -= cam.right * mouseX * cameraPanSpeed;
                cam.position = cameraCenter.position + runningOffset;
            }

            if (mouseY != 0)
            {
                cameraCenter.position -= forward * mouseY * cameraPanSpeed;
                cam.position = cameraCenter.position + runningOffset;
            }
        }
        else if (scroll != 0)
        {
            cam.position += cam.forward * scroll * zoomIntensity;
            UpdateOffsetAndRadius();
        }
    }

    void UpdatePos()
    {
        runningOffset.x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        runningOffset.z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        cam.position = cameraCenter.position + runningOffset;
    }

    void UpdateOffsetAndRadius()
    {
        runningOffset = cam.position - cameraCenter.position;
        radius = Mathf.Sqrt(Mathf.Pow(runningOffset.x, 2) + Mathf.Pow(runningOffset.z, 2));
    }

    void UpdateAngle()
    {
        angle = Mathf.Atan2(runningOffset.z, runningOffset.x) * Mathf.Rad2Deg;
    }

}
