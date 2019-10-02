using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointNClick : MonoBehaviour
{
    public bool onScreen = false;
    public GameObject onScreenPos;
    public GameObject defaultPos;   
    public float defaultXAngle = 0f;
    public float screenXAngle = 0f;
    public float smooth = 0f; // variable to smoothen the slerp
    // Update is called once per frame
    void Update()
    {
        // if onScreen then transit the camera to focus on the screen
        if (onScreen){
            transform.position = Vector3.Lerp(transform.position,onScreenPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(screenXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }else{
            // lerp the camera back to default pos
                transform.position = Vector3.Lerp(transform.position,defaultPos.transform.position,smooth);
                Quaternion target = Quaternion.Euler(defaultXAngle,-90f,0f); // y is -90 because the initial angle is -90
                transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
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
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer == 8){
                onScreen = true;
            }
        }
        // if the player clicks outside the screen
        if (Physics.Raycast(mouseRay,out rayHit, mouseRayDist)){
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer != 8){
                print("back");
                onScreen = false;
                
            }
        }
    }
}
// TODO
// transit from off-screen to on-screen...done
// transit from on-screen to off-screen
