using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed of the character
    public float rotationSpeed = 150f; // Speed of the camera rotation
    public float moveSpeed_Ysix = 5f;

    public Transform cameraTransform; // Reference to the camera

    private Vector3 moveDirection;
    public float sensitivity;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // Get input for movement (X-Z axis)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move character based on input
        moveDirection = new Vector3(moveX, 0f, moveZ);
        moveDirection = cameraTransform.forward * moveZ + cameraTransform.right * moveX;
        moveDirection.y = 0f; // Prevent movement in the Y axis (we only want X-Z movement)

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= Vector3.up * moveSpeed_Ysix * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * moveSpeed_Ysix * Time.deltaTime;

        }

        // Camera rotation (mouse)
        RotateCamera();
    }

    void RotateCamera()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}
