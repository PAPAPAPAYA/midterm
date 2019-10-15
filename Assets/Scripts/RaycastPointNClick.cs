using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastPointNClick : MonoBehaviour
{
    static public RaycastPointNClick me;

    public bool onScreen = false;
    public GameObject onScreenPos;
    public GameObject defaultPos;   
    public float defaultXAngle = 0f;
    public float screenXAngle = 0f;
    public float smooth = 0f; // variable to smoothen the slerp
    private bool screenCameraReady = false;
    public GameObject tempObjectForGlow; // for storing object that glowed

    /////////// indicators of object state
    public bool wetZippo = false;
    public bool wetPaper = false;
    public bool burntPaper = false;
    public bool burntWetPaper = false;
    public bool completedPaper = false;
    public bool onJBL = false;
    public bool brokenJBL = false;
    public bool brokenPhone = false;
    public bool wetCig = false;
    public bool lightedCig = false;

    public TextMeshProUGUI myText;

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
            //////////////////////////////////////////////////////////////////// item select
            if (Input.GetMouseButtonDown(0) && rayHit.collider.gameObject.layer == 9 && GameManagerScript.me.unlockMode){
                print( rayHit.collider.gameObject.name+" selected");
                if (rayHit.collider.gameObject.name == "Zippo"){ // igdNum = 1
                    CombineManagerScript.me.PassIngredient(1);// tell CombineManagerScript which ingredient is combing
                }
                if (rayHit.collider.gameObject.name == "mug"){ // igdNum = 2
                    CombineManagerScript.me.PassIngredient(2);
                }
                if (rayHit.collider.gameObject.name == "phone"){ // igdNum = 3
                    CombineManagerScript.me.PassIngredient(3);
                }
                if (rayHit.collider.gameObject.name == "pen"){ // igdNum = 4
                    CombineManagerScript.me.PassIngredient(4);
                }
                if (rayHit.collider.gameObject.name == "paper"){ // igdNum = 5
                    CombineManagerScript.me.PassIngredient(5);
                }
                if (rayHit.collider.gameObject.name == "seven star"){ // igdNum = 6
                    CombineManagerScript.me.PassIngredient(6);
                }
                if (rayHit.collider.gameObject.name == "jbl"){ // igdNum = 7
                    CombineManagerScript.me.PassIngredient(7);
                }
                // if (rayHit.collider.gameObject.name == "water boiler"){ // igdNum = 8
                //     CombineManagerScript.me.PassIngredient(8);
                // }
            }
            ////////////////////////////////////////////////////////////////// screen
            if (Input.GetMouseButtonDown(0)
                && (rayHit.collider.gameObject.layer == 8
                || rayHit.collider.gameObject.layer == 10
                || rayHit.collider.gameObject.layer == 11)
                && !onScreen){ // if the player click on the screen, enter the screen focus position
                onScreen = true;
            }
            if (Input.GetMouseButtonDown(0)
                && rayHit.collider.gameObject.layer != 8
                && rayHit.collider.gameObject.layer != 10
                && rayHit.collider.gameObject.layer != 11
                && onScreen){// if the player clicks outside the screen, exit the screen focus position
                onScreen = false;
            }
            /////////////////////////////////////////////////////////////// button
            if (Input.GetMouseButtonDown(0)
                && rayHit.collider.gameObject.layer == 11 // layer 11 is keyButtons, these buttons can enable unlockMode for player to combine
                && !rayHit.collider.gameObject.GetComponent<ButtonScript>().Down
                && onScreen
                && screenCameraReady)
            {
                
                rayHit.collider.gameObject.GetComponent<ButtonScript>().Down = true;
            }
            if (Input.GetMouseButtonUp(0)
                && rayHit.collider.gameObject.GetComponent<ButtonScript>() != null
                && screenCameraReady)
            {
                rayHit.collider.gameObject.GetComponent<ButtonScript>().Down = false;
                GameManagerScript.me.keyButtonClicked = true; // indicate if the key button is clicked
            }

            if (Input.GetMouseButtonDown(0)
                && rayHit.collider.gameObject.layer == 10 // layer 10 is normal buttons, only disappear once clicked
                && onScreen
                && screenCameraReady)
            {
                GameManagerScript.me.buttonClicked = true;
            }
            ////////////////////////////////////////////////////////////////// glow
            if (rayHit.collider.gameObject.layer == 9 && !onScreen && GameManagerScript.me.unlockMode){
                rayHit.collider.GetComponent<MaterialStorer>().glowing = true;
                if (rayHit.collider.gameObject.name == "mug"){
                    myText.text = "A mug, bought at Ikea. There is water in it. It's a good thing to stay hydrated.";
                }
                if (rayHit.collider.gameObject.name == "Zippo"){
                    if (wetZippo){
                        myText.text = "A Zippo lighter. Its cotten is wet.";
                    }
                    else{
                        myText.text = "A Zippo lighter. I really like it.";
                    }
                }
                if (rayHit.collider.gameObject.name == "phone"){
                    if (brokenPhone){
                        myText.text = "A phone. It's broken now.";
                    }
                    else{
                        myText.text = "A phone. Very cheap. Has lots of issue.";
                    }
                }
                if (rayHit.collider.gameObject.name == "jbl"){
                    if (brokenJBL){
                        myText.text = "A JBL Flip3 music player. It's broken.";
                    }
                    else if (onJBL){
                        myText.text = "A JBL Flip3 music player. It's playing music.";
                    }
                    else{
                        myText.text = "A JBL Flip3 music player. I really like the color. Can play music if I have my phone.";
                    }
                }
                if (rayHit.collider.gameObject.name == "pen"){
                    myText.text = "An ordinary pen. Nothing special about it. Can write on paper.";
                }
                if (rayHit.collider.gameObject.name == "paper"){
                    if (completedPaper){
                        myText.text = "My Intermediate Game Development handout. It's finished.";
                    }
                    else if (burntPaper){
                        myText.text = "My Intermediate Game Development handout. It's burnt. One less homework to do.";
                    }
                    else if (wetPaper){
                        myText.text = "My Intermediate Game Development handout. It's wet. One less homework to do.";
                    }
                    else{
                        myText.text = "My Intermediate Game Development handout. Not yet completed.";
                    }
                }
                if (rayHit.collider.gameObject.name == "seven star"){
                    if (wetCig){
                        myText.text = "A box of cigarette of brand Seven Star. All wet.";
                    }
                    else {
                        myText.text = "A box of cigarette of brand Seven Star. Good price.";
                    }
                }
                tempObjectForGlow = rayHit.collider.gameObject;
            }
            else if (rayHit.collider.gameObject.layer != 9 && tempObjectForGlow != null){
                tempObjectForGlow.GetComponent<MaterialStorer>().glowing = false;
                tempObjectForGlow = null;
            }
        }

        //if onScreen then transit the camera to focus on the screen
        if (onScreen)
        {
            transform.position = Vector3.Lerp(transform.position,onScreenPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(screenXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
            if (Vector3.Distance(transform.position,onScreenPos.transform.position)<0.1f){
                transform.position = onScreenPos.transform.position;
                screenCameraReady = true;
            }
        }
        else if(!onScreen)
        {
            // lerp the camera back to default pos
            transform.position = Vector3.Lerp(transform.position, defaultPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(defaultXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
            screenCameraReady = false;
        }
    }
}