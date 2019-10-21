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

    [Header("indicators of object state")]
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

    [Header("text")]
    public TextMeshProUGUI myText;
    public string textToBeDisplayed;

    public string burntText = "";
    public string wetText = "";
    public string burntWetText = "";
    public string completedText = "";

    [Header("ending")]
    public bool ending = false;
    public GameObject screen;
    public GameObject endingCameraPos;

    [Header("sound")]
    public AudioSource mouseClick;

    private void Awake() {
        me = this;
    }

    void Update()
    {
        if (CombineManagerScript.me.combineText.Length < 4){
            myText.text = textToBeDisplayed;
        }
        else{
            myText.text = CombineManagerScript.me.combineText;
        }
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
                if (rayHit.collider.gameObject.name == "Zippo"){ // igdNum = 1
                    if (!CombineManagerScript.me.igdZippo){
                        CombineManagerScript.me.PassIngredient(1);// tell CombineManagerScript which ingredient is combining
                    }
                    else if (CombineManagerScript.me.igdZippo){
                        CombineManagerScript.me.igdZippo = false;
                    }
                }
                if (rayHit.collider.gameObject.name == "mug"){
                    if (!CombineManagerScript.me.igdMug){
                        CombineManagerScript.me.PassIngredient(2);
                    } // igdNum = 2
                    else if (CombineManagerScript.me.igdMug){
                        CombineManagerScript.me.igdMug = false;
                    }
                }
                if (rayHit.collider.gameObject.name == "phone"){
                    if (!CombineManagerScript.me.igdPhone){
                        CombineManagerScript.me.PassIngredient(3);
                    } // igdNum = 3
                    else if (CombineManagerScript.me.igdPhone){
                        CombineManagerScript.me.igdPhone = false;
                    }
                }
                if (rayHit.collider.gameObject.name == "pen"){
                    if (!CombineManagerScript.me.igdPen){
                        CombineManagerScript.me.PassIngredient(4);
                    } // igdNum = 4
                    else if (CombineManagerScript.me.igdPen){
                        CombineManagerScript.me.igdPen = false;
                    }
                }
                if (rayHit.collider.gameObject.name == "paper"){
                    if (!CombineManagerScript.me.igdPaper){
                        CombineManagerScript.me.PassIngredient(5);
                    } // igdNum = 5
                    else if (CombineManagerScript.me.igdPaper){
                        CombineManagerScript.me.igdPaper = false;
                    }
                }
                if (rayHit.collider.gameObject.name == "seven star"){
                    if (!CombineManagerScript.me.igdCig){
                        CombineManagerScript.me.PassIngredient(6);
                    } // igdNum = 6
                    else if (CombineManagerScript.me.igdCig){
                        CombineManagerScript.me.igdCig = false;
                    }
                }
                if (rayHit.collider.gameObject.name == "jbl"){
                    if (!CombineManagerScript.me.igdJbl){
                        CombineManagerScript.me.PassIngredient(7);
                    } // igdNum = 7
                    else if (CombineManagerScript.me.igdJbl){
                        CombineManagerScript.me.igdJbl = false;
                    }
                }

                // else if (rayHit.collider.gameObject.name == "Zippo" && CombineManagerScript.me.igdZippo){ // igdNum = 1
                //     CombineManagerScript.me.igdZippo = false;// tell CombineManagerScript to unselect
                // }
                // else if (rayHit.collider.gameObject.name == "mug" && CombineManagerScript.me.igdMug){ // igdNum = 2
                //     CombineManagerScript.me.igdMug = false;
                // }
                // else if (rayHit.collider.gameObject.name == "phone" && CombineManagerScript.me.igdPhone){ // igdNum = 3
                //     CombineManagerScript.me.igdPhone = false;
                // }
                // else if (rayHit.collider.gameObject.name == "pen" && CombineManagerScript.me.igdPen){ // igdNum = 4
                //     CombineManagerScript.me.igdPen = false;
                // }
                // else if (rayHit.collider.gameObject.name == "paper" && CombineManagerScript.me.igdPaper){ // igdNum = 5
                //     CombineManagerScript.me.igdPaper = false;
                // }
                // else if (rayHit.collider.gameObject.name == "seven star" && CombineManagerScript.me.igdCig){ // igdNum = 6
                //     CombineManagerScript.me.igdCig = false;
                // }
                // else if (rayHit.collider.gameObject.name == "jbl" && CombineManagerScript.me.igdJbl){ // igdNum = 7
                //     CombineManagerScript.me.igdJbl = false;
                // }
                rayHit.collider.gameObject.GetComponent<MaterialStorer>().selected = true; // indicate if the object is selected, if true then object glows
            }
            if (Input.GetMouseButtonDown(0) && rayHit.collider.gameObject.layer == 8 && GameManagerScript.me.unlockMode && ending){
                if (!CombineManagerScript.me.igdScreen){
                    CombineManagerScript.me.PassIngredient(8); // if selected screen
                    rayHit.collider.gameObject.GetComponent<MaterialStorer>().selected = true;
                }
                else{
                    CombineManagerScript.me.igdScreen = false;
                }
                
            }
            ////////////////////////////////////////////////////////////////// screen
            if (Input.GetMouseButtonDown(0)
                && (rayHit.collider.gameObject.layer == 8
                || rayHit.collider.gameObject.layer == 10
                || rayHit.collider.gameObject.layer == 11)
                && !onScreen
                && !ending){ // if the player click on the screen, enter the screen focus position
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
                && onScreen
                && screenCameraReady)
            {
                GameManagerScript.me.keyButtonClicked = true; // indicate if the key button is clicked
                mouseClick.PlayOneShot(mouseClick.clip);
            }

            if (Input.GetMouseButtonDown(0)
                && rayHit.collider.gameObject.layer == 10 // layer 10 is normal buttons, only disappear once clicked
                && onScreen
                && screenCameraReady)
            {
                GameManagerScript.me.buttonClicked = true;
                mouseClick.PlayOneShot(mouseClick.clip);
            }
            ////////////////////////////////////////////////////////////////// glow
            if (rayHit.collider.gameObject.layer == 8 && !onScreen && GameManagerScript.me.unlockMode && ending){
                rayHit.collider.GetComponent<MaterialStorer>().glowing = true;
                textToBeDisplayed = "A computer. Source of pain.";
                tempObjectForGlow = rayHit.collider.gameObject;
            }
            else if (rayHit.collider.gameObject.layer != 8 && tempObjectForGlow != null && rayHit.collider.gameObject.layer != 9){
                tempObjectForGlow.GetComponent<MaterialStorer>().glowing = false;
                CombineManagerScript.me.combineText = "";
                tempObjectForGlow = null;
            }

            if (rayHit.collider.gameObject.layer == 9 && !onScreen && GameManagerScript.me.unlockMode){
                rayHit.collider.GetComponent<MaterialStorer>().glowing = true;
                if (rayHit.collider.gameObject.name == "mug"){
                    textToBeDisplayed = "A mug, bought at Ikea. There is water in it. It's a good thing to stay hydrated.";
                }
                if (rayHit.collider.gameObject.name == "Zippo"){
                    if (wetZippo){
                        textToBeDisplayed = "A Zippo lighter. Its cotten is wet.";
                    }
                    else{
                        textToBeDisplayed = "A Zippo lighter. I really like it.";
                    }
                }
                if (rayHit.collider.gameObject.name == "phone"){
                    if (brokenPhone){
                        textToBeDisplayed = "A phone. It's broken now.";
                    }
                    else{
                        textToBeDisplayed = "A phone. Very cheap. Has lots of issue.";
                    }
                }
                if (rayHit.collider.gameObject.name == "jbl"){
                    if (brokenJBL){
                        textToBeDisplayed = "A JBL Flip3 music player. It's broken.";
                    }
                    else if (onJBL){
                        textToBeDisplayed = "A JBL Flip3 music player. It's playing music.";
                    }
                    else{
                        textToBeDisplayed = "A JBL Flip3 music player. I really like the color. Can play music if I have my phone.";
                    }
                }
                if (rayHit.collider.gameObject.name == "pen"){
                    textToBeDisplayed = "An ordinary pen. Nothing special about it. Can write on paper.";
                }
                if (rayHit.collider.gameObject.name == "paper"){
                    
                    textToBeDisplayed = "My Intermediate Game Development handout."+ burntText + wetText + burntWetText + completedText;
                    if (completedPaper){
                        completedText = " It's finished.";
                    }
                    if (burntWetPaper && !completedPaper){
                        burntWetText = " It's a mess. One less homework to do.";
                        burntText = "";
                        wetText = "";
                    }
                    if (burntWetPaper && completedPaper){
                        burntWetText = " It's a mess.";
                        burntText = "";
                        wetText = "";
                    }
                    if (burntPaper && !wetPaper && !completedPaper && !burntWetPaper){
                        burntText = " It's burnt. One less homework to do.";
                    }
                    if (burntPaper && !wetPaper && completedPaper && !burntWetPaper){
                        burntText = " It's burnt.";
                    }
                    if (wetPaper && !burntPaper && !completedPaper && !burntWetPaper){
                        wetText = " It's wet. Still need to do it later.";
                    }
                    if (wetPaper && !burntPaper && completedPaper && !burntWetPaper){
                        wetText = " It's wet.";
                    }
                }
                if (rayHit.collider.gameObject.name == "seven star"){
                    if (wetCig){
                        textToBeDisplayed = "A box of cigarette of brand Seven Star. All wet.";
                    }
                    else {
                        textToBeDisplayed = "A box of cigarette of brand Seven Star. Good price.";
                    }
                }
                tempObjectForGlow = rayHit.collider.gameObject;
            }
            else if (rayHit.collider.gameObject.layer != 9 && tempObjectForGlow != null && rayHit.collider.gameObject.layer != 8){
                tempObjectForGlow.GetComponent<MaterialStorer>().glowing = false;
                CombineManagerScript.me.combineText = "";
                tempObjectForGlow = null;
            }
        }

        //if onScreen then transit the camera to focus on the screen
        if (onScreen)
        {
            transform.position = Vector3.Lerp(transform.position,onScreenPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(screenXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
            if (Vector3.Distance(transform.position,onScreenPos.transform.position)<0.002f){
                transform.position = onScreenPos.transform.position;
                screenCameraReady = true;
            }
        }
        if(!onScreen && !ending)
        {
            // lerp the camera back to default pos
            transform.position = Vector3.Lerp(transform.position, defaultPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(defaultXAngle,-90f,0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
            screenCameraReady = false;
        }

        // if in the ending change the camera angle so the player can see the screen
        if (ending && !onScreen){
            transform.position = Vector3.Lerp(transform.position,endingCameraPos.transform.position,smooth);
            Quaternion target = Quaternion.Euler(12.384f, -90f, 0f); // y is -90 because the initial angle is -90
            transform.rotation = Quaternion.Slerp(transform.rotation,target,smooth);
        }
    }
}