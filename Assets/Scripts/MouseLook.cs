using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    float verticalAngle = 0f; // store vertical look in a separate variable
    //so as to avoid eulerangles wraparound from 180 to -180, etc.
    float horizontalAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //returns "0" if we aren't moving the mouse
        float mouseX = Input.GetAxis("Mouse X");//horizontal mouse velocity
        float mouseY = Input.GetAxis("Mouse Y");//vertival mouse velocity

        //transform.parent.Rotate(0f, horizontalAngle, 0f);//rotate the parent of camera which is the cube

        //float verticalAngle = transform.localEulerAngles.x;
        verticalAngle -= mouseY * 5f;
        verticalAngle = Mathf.Clamp(verticalAngle, -10f, 20f);

        // trying to clamp horizontalAngle
        horizontalAngle += mouseX * 10f;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -100f, -80f);

        //X = pitch, Y = Yaw, Z = Roll..set z = 0f to unroll the camera
        transform.localEulerAngles = new Vector3(verticalAngle, horizontalAngle, 0f);
    }
}