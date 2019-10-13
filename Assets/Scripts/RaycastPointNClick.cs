using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointNClick : MonoBehaviour
{
    static public RaycastPointNClick me;

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
    
    public bool onObject = false;
    public GameObject daObject;
    public GameObject examinePos;
    
    public GameObject tempObjectForGlow; // for storing object that glowed
    //--------------------------------------------------------

    // for object examination
    float verticalAngle = 0f; // store vertical look in a separate variable
    //so as to avoid eulerangles wraparound from 180 to -180, etc.
    float horizontalAngle = 0f;
    public float objectSmooth = 0; // variable to smoothen the examination
    //--------------------------------------------------------

    // for dragging objects
    [Header("dragging object")]
    public Transform objectDefaultPos;
    public float examineSmooth;
    private bool draggingObject = false;
    private GameObject tempObject;
    private float yToBeClamped;
    private float xToBeClamped;
    private float zToBeClamped;

    private void Awake() {
        me = this;
    }

    void Update()
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
            //////////////////////////////////////////////////////////////////// drag object
            if (Input.GetMouseButtonDown(0) && rayHit.collider.gameObject.layer == 9 && GameManagerScript.me.unlockMode){
                tempObject = rayHit.collider.gameObject;
                objectDefaultPos.position = rayHit.collider.gameObject.transform.position;
                draggingObject = true;
            }
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer == 9 && GameManagerScript.me.unlockMode){
                rayHit.transform.position = rayHit.point;
                yToBeClamped = 0.658f;
                xToBeClamped = Mathf.Clamp(rayHit.transform.position.x,-0.2f,0.82f);
                zToBeClamped = Mathf.Clamp(rayHit.transform.position.z,-2,2);
                rayHit.transform.position = new Vector3 (xToBeClamped, yToBeClamped, rayHit.transform.position.z);
            }
            if (Input.GetMouseButtonUp(0) && rayHit.collider.gameObject.layer == 9 && GameManagerScript.me.unlockMode){
                draggingObject = false;
            }
            ////////////////////////////////////////////////////////////////// screen
            if (Input.GetMouseButtonDown(0) && (rayHit.collider.gameObject.layer == 8 || rayHit.collider.gameObject.layer == 10) && !onScreen && !onObject){// if the player click on the screen, enter the screen focus position
                onScreen = true;
            }
            if (Input.GetMouseButtonDown(0) && rayHit.collider.gameObject.layer != 8 && rayHit.collider.gameObject.layer != 10 && onScreen){// if the player clicks outside the screen, exit the screen focus position
                onScreen = false;
            }
            /////////////////////////////////////////////////////////////// button
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer == 10 && !rayHit.collider.gameObject.GetComponent<ButtonScript>().Down
                && !onObject){
                rayHit.collider.gameObject.GetComponent<ButtonScript>().Down = true;
            }
            if (Input.GetMouseButtonUp(0) && rayHit.collider.gameObject.GetComponent<ButtonScript>() != null){
                rayHit.collider.gameObject.GetComponent<ButtonScript>().Down = false;
                GameManagerScript.me.buttonClicked = true; // indicate if the button is clicked
            }
            ////////////////////////////////////////////////////////////////// glow
            if (rayHit.collider.gameObject.layer == 9){
                print("on layer 9");
            }
            if (rayHit.collider.gameObject.layer == 9 && !onObject && !onScreen && (rayHit.collider.gameObject.GetComponent<MaterialStorer>().active
                || GameManagerScript.me.unlockMode)){
                //print("glow");
                rayHit.collider.GetComponent<MaterialStorer>().glowing = true;
                tempObjectForGlow = rayHit.collider.gameObject;
            }
            else if (rayHit.collider.gameObject.layer != 9 && tempObjectForGlow != null){
                tempObjectForGlow.GetComponent<MaterialStorer>().glowing = false;
                tempObjectForGlow = null;
            }

            /////////////////////////////////////////////////////////////////// unlock object by clicking
            // if (GameManagerScript.me.unlockMode){
            //     if (Input.GetMouseButtonDown(0) && rayHit.collider.gameObject.layer == 9){
            //         rayHit.collider.GetComponent<MaterialStorer>().active = true;
            //         GameManagerScript.me.objectUnlockedNum++;
            //     }
            // }
        }
        // drag
        if (!draggingObject && tempObject != null){
            tempObject.transform.position = Vector3.Lerp(tempObject.transform.position, objectDefaultPos.position, examineSmooth);
        }

        //if onScreen then transit the camera to focus on the screen
        if (onScreen)
        {
            transform.position = Vector3.Lerp(transform.position,onScreenPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(screenXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }
        else if(!onScreen)
        {
            // lerp the camera back to default pos
            transform.position = Vector3.Lerp(transform.position, defaultPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(defaultXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }
    }
}