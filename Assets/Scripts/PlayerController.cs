using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Define float variables
    private float mouseY;
    private float mouseX;
    private float horzInput;
    private float vertInput;
    private float xRotation = 0f;
    [SerializeField] float sensitivity = 100.0f;
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
    // Set mouseX and Y variables with appropriate operations.
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
    // Do the same for horizontal and vertical movement.
        horzInput = Input.GetAxis("Horizontal") * (movementSpeed * 0.33f) * Time.deltaTime;
        vertInput = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
    // Call functions
        CameraControl();
        playerMovement();
    }

    private void CameraControl()
    {
        //actual rotation
        transform.Rotate(Vector3.up, mouseX);
        //clamp!
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        //actual rotation but this time for y.
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void playerMovement()
    {
        //movement i guess?
        transform.Translate(Vector3.forward * vertInput);
        transform.Translate(Vector3.right * horzInput);
    }
}
