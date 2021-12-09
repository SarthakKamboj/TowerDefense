using UnityEngine;
using Cinemachine;

public class CameraPan : MonoBehaviour
{

    [SerializeField] Transform cameraCenter;
    [SerializeField] float cameraPanSpeed = 2f;
    [SerializeField] GameObject ground;

    float radius;
    float angle;
    Vector3 runningOffset;
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;

        runningOffset = Camera.main.transform.position - cameraCenter.position;
        radius = Mathf.Sqrt(Mathf.Pow(runningOffset.x, 2) + Mathf.Pow(runningOffset.z, 2));
        angle = Mathf.Atan2(runningOffset.z, runningOffset.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            angle -= Input.GetAxisRaw("Mouse X");
            UpdatePos();
            cam.rotation = Quaternion.LookRotation(-runningOffset.normalized, Vector3.up);
        }
        else if (Input.GetMouseButton(2))
        {
            cameraCenter.position -= cam.right * Input.GetAxisRaw("Mouse X") * cameraPanSpeed;
            cam.position = cameraCenter.position + runningOffset;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
            if (scroll > 0f)
            {
                cam.position += cam.forward;
                UpdateOffsetAndRadius();
            }
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

}
