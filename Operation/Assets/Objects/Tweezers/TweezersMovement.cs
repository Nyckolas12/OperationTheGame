using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TweezersMovement : MonoBehaviour
{
    //Jadan: we should probably shange these to be assigned to a ScriptableObject later so that its easier to tweak
    [Header("Movement")]
    public float moveSpeed = 0.15f;
    public float verticalSpeed = 0.1f;

    [Header("Rotation")]
    public float rotateSpeed = 80f;

    [Header("Clamp Speed")]
    public float clampSpeed = 80f;
    

    public float testvar = 1f;

    //
    private GameObject leftProng;
    private GameObject rightProng;
    

    private void Start()
    {
        List<Transform> allDescendants = this.GetComponentsInChildren<Transform>(true).ToList();
        //:(
        leftProng = allDescendants.Where(a => a.gameObject.name == "leftP").First().gameObject;
        rightProng = allDescendants.Where(a => a.gameObject.name == "rightP").First().gameObject;

    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleClamping();
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

    //animations for closing
    //if close button == pressed
    //  if left rotation >= 90 and right rotation >=-90 then do nothing,
    //  else 
    //      increase rotations by a certain amount each update * dt
    //else
    //  return to default position

    void HandleClamping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            leftProng.transform.localRotation = Quaternion.Euler(0, 90, 90);
            rightProng.transform.localRotation = Quaternion.Euler(0, -90, -90);
        }
        else
        {
            leftProng.transform.localRotation = Quaternion.Euler(0, 70, 90);
            rightProng.transform.localRotation = Quaternion.Euler(0, -70, -90);
        }
    }
}
