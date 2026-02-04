using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
     
        // DEBUG 1: Check if the mouse is even sending vertical data
        if (mouseY != 0) 
        {
            Debug.Log($"Mouse Y Input: {mouseY}");
        }

        // Vertical look (camera)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        // DEBUG 2: Check the final angle being sent to the rotation
        // Debug.Log($"Target X Rotation: {xRotation}");

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal look (player body)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
