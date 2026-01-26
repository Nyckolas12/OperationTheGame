using UnityEngine;

public class TweezersMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 0.15f;
    public float verticalSpeed = 0.1f;

    [Header("Rotation")]
    public float rotateSpeed = 80f;

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");   // A / D
        float z = Input.GetAxis("Vertical");     // W / S

        float y = 0f;
        if (Input.GetKey(KeyCode.E)) y = 1f;     // Up
        if (Input.GetKey(KeyCode.Q)) y = -1f;    // Down

        Vector3 move =
            transform.right * x * moveSpeed +
            transform.forward * z * moveSpeed +
            transform.up * y * verticalSpeed;

        transform.position += move * Time.deltaTime;
    }

    void HandleRotation()
    {
        if (!Input.GetMouseButton(1)) return; // Right mouse held

        float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float rotY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, rotX, Space.World);
        transform.Rotate(Vector3.right, -rotY, Space.Self);
    }
}
