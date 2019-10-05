﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public RaycastPointNClick pNCScript;
    float verticalAngle = 0f; // store vertical look in a separate variable
    //so as to avoid eulerangles wraparound from 180 to -180, etc.
    float horizontalAngle = 0f;
    public float smooth = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pNCScript.onScreen && !pNCScript.onObject){
        //returns "0" if we aren't moving the mouse
        float mouseX = Input.GetAxis("Mouse X");//horizontal mouse velocity
        float mouseY = Input.GetAxis("Mouse Y");//vertival mouse velocity

        //transform.parent.Rotate(0f, horizontalAngle, 0f);//rotate the parent of camera which is the cube

        //float verticalAngle = transform.localEulerAngles.x;
        verticalAngle -= mouseY * 1f;
        verticalAngle = Mathf.Clamp(verticalAngle, -10f, 20f);

        // trying to clamp horizontalAngle
        horizontalAngle += mouseX * 2f;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -100f, -80f);

        //X = pitch, Y = Yaw, Z = Roll..set z = 0f to unroll the camera
        //transform.localEulerAngles = new Vector3(verticalAngle, horizontalAngle, 0f);
        Quaternion target = Quaternion.Euler(verticalAngle,horizontalAngle,0f);
        transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }
    }
}