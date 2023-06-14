using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX, sensY, maxRotationY, MinRotationY;
    public Transform orientation;

    float xRotation, yRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor
        Cursor.visible = false;
    }
    
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, maxRotationY, MinRotationY); //clamp the value so you can't rotate forever

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
