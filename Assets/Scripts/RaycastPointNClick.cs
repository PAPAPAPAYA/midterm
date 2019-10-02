using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointNClick : MonoBehaviour
{
    // for transition between screen and off-screen
    [Header("on/off screen")]
    public bool onScreen = false;
    public GameObject onScreenPos;
    public GameObject defaultPos;   
    public float defaultXAngle = 0f;
    public float screenXAngle = 0f;
    public float smooth = 0f; // variable to smoothen the slerp
    //---------------------------------------------------------
    
    // for transition between off-screen and object examine
    [Header("on/off object")]
    public bool onObject = false;
    public GameObject daObject;
    public GameObject examinePos;
    public GameObject objectDefaultPos;
    public float examineSmooth;
    //--------------------------------------------------------



    // Update is called once per frame
    void Update()
    {
        // if onScreen then transit the camera to focus on the screen
        if (onScreen){
            transform.position = Vector3.Lerp(transform.position,onScreenPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(screenXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }else if(!onScreen) {
            // lerp the camera back to default pos\
            transform.position = Vector3.Lerp(transform.position, defaultPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(defaultXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }
        if (onObject){
            daObject.transform.position = Vector3.Lerp(daObject.transform.position, examinePos.transform.position, examineSmooth);

            // if (Input.GetMouseButton(1)){
            //     onObject = false;
            // }
        }else if (!onObject && daObject != null){
            daObject.transform.position = Vector3.Lerp(daObject.transform.position, objectDefaultPos.transform.position, examineSmooth);
        }


        // STEP 1: declare a ray, use mouse's screenspace pixel coordinate
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // STEP 2: declare mouse ray distance
        float mouseRayDist = 10000f;

        // STEP 2B: declare a blank RaycastHit variable
        RaycastHit rayHit = new RaycastHit();

        // STEP 3: debug draw the raycast
        Debug.DrawRay(mouseRay.origin,mouseRay.direction * mouseRayDist, Color.magenta);

        // STEP 4: shoot the raycast

        
        
        if (Physics.Raycast(mouseRay,out rayHit, mouseRayDist)){
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer == 8){// if the player click on the screen, enter the screen focus position
                onScreen = true;
            }
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer != 8){// if the player clicks outside the screen, exit the screen focus position
                onScreen = false;
            }
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer == 9){
                onObject = true;
                daObject = rayHit.collider.gameObject;
            }
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer != 9 && onObject == true){
                onObject = false;
                daObject.transform.position = Vector3.Lerp(daObject.transform.position, objectDefaultPos.transform.position, examineSmooth);
            }
        }
    }
}
// TODO
// transit from off-screen to on-screen...done
// transit from on-screen to off-screen...done
// transit between off-screen and object examine position...done
// rotate the object in object examine position