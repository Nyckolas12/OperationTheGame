using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 4f;
    public float rotateSpeed = 120f;
    public float zoomSpeed = 2f;
    public float minDistance = 2f;
    public float maxDistance = 6f;

    private float yaw;
    private float pitch;

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetMouseButton(0)) // Left mouse
        {
            yaw += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, -30f, 75f);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}
