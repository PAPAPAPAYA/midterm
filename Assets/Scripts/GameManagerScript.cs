using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    static public GameManagerScript me;

    [Header("for clicking buttons")]
    public GameObject keyButton1;
    public GameObject keyButton2;
    public GameObject keyButton3;
    
    public GameObject waitButton;
    public GameObject normalButton1;
    public GameObject normalButton2;
    public GameObject normalButton3;
    
    public bool buttonClicked = false;
    public bool keyButtonClicked = false;
    public bool unlockMode = false;
    public int phase = 1;
    public int subPhase = 1;

    [Header("Screen Management")]
    public GameObject confirmScreen1;
    public GameObject endScreen;
    

    [Header("for progress bar")]
    public GameObject progressBar;
    public GameObject confirmButton1;
    public GameObject confirmButton2;
    public GameObject confirmButton3;
    public float combinationNum = 0f;
    public float combinationRequirement1 = 0f;
    public float combinationRequirement2 = 0f;
    public float combinationRequirement3 = 0f;
    public float barSmooth = 0;
    private bool showBar = false;
    private Vector3 pBTargetScale;
    private float pBFullXScale = 0.252863f;
    public bool waitDone = false;
    
    public bool gameOver = false;

    
    private void Awake() {
        me = this;
    }

    private void Update() {
        print(phase);
        //////////////////////////////////////// phase 1
        if (!unlockMode && phase == 1){
            RaycastPointNClick.me.textToBeDisplayed = "i should build my project by clicking it.";
        }
        if (keyButtonClicked && phase == 1){ // unlockmode is on once the key button is clicked
            keyButton1.SetActive(false);
            waitButton.SetActive(true);
            unlockMode = true;
            keyButtonClicked = false;
            showBar = true;
            RaycastPointNClick.me.textToBeDisplayed = "Let me click outside the screen to see what I can do to kill some time. I can try choosing two objects by clicking them.";
        }
        if (buttonClicked && phase == 1){ // disable confirmButton when clicked
            confirmButton1.SetActive(false);
            confirmScreen1.SetActive(false);
            waitButton.SetActive(false);
            buttonClicked = false;
            showBar = false;
            combinationNum = 0;
            phase = 2;
            keyButton1.SetActive(true);
            //print("keyButton set active");
        }
        //////////////////////////////////////// phase 2
        if (keyButtonClicked && phase == 2){ // unlockmode is on once the key button is clicked
            keyButton1.SetActive(false);
            waitButton.SetActive(true);
            unlockMode = true;
            keyButtonClicked = false;
            showBar = true;
            RaycastPointNClick.me.textToBeDisplayed = "Okay, let me kill more time.";
        }
        if (buttonClicked && phase == 2){ // disable confirmButton when clicked
            confirmButton1.SetActive(false);
            confirmScreen1.SetActive(false);
            waitButton.SetActive(false);
            buttonClicked = false;
            showBar = false;
            combinationNum = 0;
            phase = 3;
            keyButton1.SetActive(true);
        }
        ///////////////////////////////////// phase 3 (ending)
        if (keyButtonClicked && phase == 3){
            keyButton1.SetActive(false);
            waitButton.SetActive(true);
            endScreen.SetActive(true);
            unlockMode = true;
            keyButtonClicked = false;
            showBar = true;
            RaycastPointNClick.me.textToBeDisplayed = "I can't take this anymore.";
            RaycastPointNClick.me.ending = true;
        }
        // if (keyButtonClicked && phase == 3 && subPhase == 6){ // also make screen selectable
        //     waitDone = false;
        //     keyButton3.SetActive(false);
        //     waitButton.SetActive(true);
        //     unlockMode = true;
        //     keyButtonClicked = false;
        //     showBar = true;
        //     RaycastPointNClick.me.textToBeDisplayed = "I can't take this anymore.";
        //     subPhase = 7;
        // }
        // if (buttonClicked && phase == 3 && subPhase == 7){ // disable confirmButton when clicked
        //     confirmButton3.SetActive(false);
        //     waitButton.SetActive(false);
        //     buttonClicked = false;
        //     showBar = false;
        //     subPhase = 999;
        //     print("done");
        // }
        

        //////////////////////////////////////////////////////////// progress bar
        if (showBar){
            progressBar.SetActive(true);
        }
        else if (!showBar){
            progressBar.SetActive(false);
        }
        if (phase == 1){
            pBTargetScale = new Vector3 ((combinationNum/combinationRequirement1) * pBFullXScale, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
        }
        else if (phase == 2){
            pBTargetScale = new Vector3 ((combinationNum/combinationRequirement2) * pBFullXScale, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
        }
        else if (phase == 3){
            pBTargetScale = new Vector3 ((combinationNum/combinationRequirement3) * pBFullXScale, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
        }
        progressBar.transform.localScale = Vector3.Lerp(progressBar.transform.localScale, pBTargetScale, barSmooth); // progress bar increase for an amount based on the combinations made and combination required
        if (pBFullXScale - progressBar.transform.localScale.x < 0.005f && unlockMode){ // when progress bar is increased enough show confirmButton, disable unlockMode
            progressBar.transform.localScale = pBTargetScale;
            
            if (phase == 1){
                confirmButton1.SetActive(true);
                confirmScreen1.SetActive(true);
                RaycastPointNClick.me.textToBeDisplayed = "The wait is done.";
            }
            else if (phase == 2){
                confirmButton1.SetActive(true);
                confirmScreen1.SetActive(true);
                waitDone = true;
                RaycastPointNClick.me.textToBeDisplayed = "The wait is done. I should get back to my screen.";
            }
            else if (phase == 3){
                confirmButton3.SetActive(true);
                gameOver = true;
                RaycastPointNClick.me.textToBeDisplayed = "Good day. Game over.";
                SceneManager.LoadScene("EndScene");
            }
            unlockMode = false;
        }
    }
}

// set up an array to store which type of button to display: 0 for normal; 1 for key
// show the next button when confirmButton is clicked