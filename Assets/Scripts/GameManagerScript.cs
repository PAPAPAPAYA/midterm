using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    private float pBFullXScale = 0.2482126f;
    public bool waitDone = false;
    
    public bool gameOver = false;

    public TextMeshPro endPercentage;


    
    private void Awake() {
        me = this;
    }

    private void Update() {
        print(phase);
        //////////////////////////////////////// phase 1
        if (!unlockMode && phase == 1 && !waitDone){
            RaycastPointNClick.me.textToBeDisplayed = "I should build my project by clicking it.";
        }
        if (!unlockMode && phase == 2 && !waitDone){
            RaycastPointNClick.me.textToBeDisplayed = "Okey, let's try to build again.";
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
            RaycastPointNClick.me.textToBeDisplayed = "Okey, let's try to build again.";
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
            RaycastPointNClick.me.textToBeDisplayed = "Gotta kill more time.";
        }
        if (buttonClicked && phase == 2){ // disable confirmButton when clicked
            RaycastPointNClick.me.textToBeDisplayed = "Well, have to do it again.";
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
            endScreen.SetActive(true);
            endPercentage.gameObject.SetActive(true);
            unlockMode = true;
            keyButtonClicked = false;
            showBar = false;
            RaycastPointNClick.me.textToBeDisplayed = "I can't take this anymore.";
            RaycastPointNClick.me.ending = true;
        }
        

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
        else if (phase == 3){ // instead of using the progress bar, use endPercentage(
            endPercentage.text =  Mathf.RoundToInt(combinationNum/combinationRequirement3 * 100).ToString();
            //pBTargetScale = new Vector3 ((combinationNum/combinationRequirement3) * pBFullXScale, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
        }
        progressBar.transform.localScale = Vector3.Lerp(progressBar.transform.localScale, pBTargetScale, barSmooth); // progress bar increase for an amount based on the combinations made and combination required
        if (pBFullXScale - progressBar.transform.localScale.x < 0.005f && unlockMode && phase != 3){ // when progress bar is increased enough show confirmButton, disable unlockMode
            progressBar.transform.localScale = pBTargetScale;
            
            if (phase == 1){
                confirmButton1.SetActive(true);
                confirmScreen1.SetActive(true);
                waitDone = true;
                RaycastPointNClick.me.textToBeDisplayed = "What the...";
            }
            else if (phase == 2){
                confirmButton1.SetActive(true);
                confirmScreen1.SetActive(true);
                waitDone = true;
                RaycastPointNClick.me.textToBeDisplayed = "WHAT THE...";
            }
            // else if (phase == 3){
            //     // confirmButton3.SetActive(true);
            //     // gameOver = true;
            //     // RaycastPointNClick.me.textToBeDisplayed = "Good day. Game over.";
            //     // SceneManager.LoadScene("EndScene");
            // }
            unlockMode = false;
        }
        if ( Mathf.RoundToInt(combinationNum/combinationRequirement3 * 100) > 99 && phase == 3){
            endPercentage.text = "100";
            gameOver = true;
            RaycastPointNClick.me.textToBeDisplayed = "Good day. Game over.";
            SceneManager.LoadScene("EndScene");
        }
    }
}

// set up an array to store which type of button to display: 0 for normal; 1 for key
// show the next button when confirmButton is clicked