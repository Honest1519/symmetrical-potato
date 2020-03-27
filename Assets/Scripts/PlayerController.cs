using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables for game object, the camera's rotation (in a quaternion), bools for quaternion clamping, the mouses rotation and rotation speed in floats.
    [SerializeField] GameObject mainCamera;
    [SerializeField] Quaternion CameraY;
    [SerializeField] float rotationSpeed = 50.0f;
    public float mouseY;
    public float mouseX;
    [SerializeField] bool yTooHigh;
    [SerializeField] bool yTooNotHigh;
    
    // Start is called before the first frame update.
    void Start()
    {
    //Lock the cursor to the center of the screen.
    Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame.
    void Update()
    {
        //set mousex and y variables to actual mouse x and y
        mouseY = Input.GetAxis("Mouse Y");
        mouseX = Input.GetAxis("Mouse X");
        //call functions
        CameraControl();
        MouseYClamp();
        //set quaternion to rotation of camera
        CameraY = mainCamera.transform.rotation;
        Debug.Log("mouseY =" + mouseY);
    }

   //function for camera control.
    public void CameraControl() {
    //rotate the camera on y axis when mouse y changes (but only on both false, otherwise return to false)
    if(!yTooHigh && !yTooNotHigh) {
    mainCamera.transform.Rotate(-Vector3.right, mouseY * Time.deltaTime * rotationSpeed);
    } 
    if(yTooHigh) {
    mainCamera.transform.Rotate(Vector3.right, 1 * Time.deltaTime * rotationSpeed);
    } 
    if(yTooNotHigh) {
    mainCamera.transform.Rotate(Vector3.right, -1 * Time.deltaTime * rotationSpeed);
    }
    //rotate the camera on x axis when mouse x changes.
    transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotationSpeed);
    //mainCamera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    //uhoh uhoh clamping.
    public void MouseYClamp() {
    //negative quaternion value to boolean.
    if(CameraY.x < -0.5){
    yTooHigh = true;
    } else {
        yTooHigh = false;
    }
    //positive quaternion value to boolean.
    if(CameraY.x > 0.5){
    yTooNotHigh = true;
    } else {
        yTooNotHigh = false;
    }
    }
}
