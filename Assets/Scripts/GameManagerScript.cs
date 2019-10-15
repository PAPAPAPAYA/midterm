using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    static public GameManagerScript me;
    
    [Header("for clicking buttons")]
    public GameObject keyButton1;
    public GameObject waitButton;
    public GameObject normalButton1;
    public GameObject keyButton2;
    public bool buttonClicked = false;
    public bool keyButtonClicked = false;
    public bool unlockMode = false;
    private int phase = 1;
    private int subPhase = 1;
    

    [Header("for progress bar")]
    public GameObject progressBar;
    public GameObject confirmButton1;
    public GameObject confirmButton2;
    public float combinationNum = 0f;
    public float combinationRequirement1 = 0f;
    public float combinationRequirement2 = 0f;
    public float barSmooth = 0;
    private bool showBar = false;
    private Vector3 pBTargetScale;
    private float pBFullXScale = 1;
    

    
    private void Awake() {
        me = this;
    }

    private void Update() {
        if (keyButtonClicked && phase == 1){ // unlockmode is on once the key button is clicked
            keyButton1.SetActive(false);
            waitButton.SetActive(true);
            unlockMode = true;
            keyButtonClicked = false;
            showBar = true;
        }
        if (buttonClicked && phase == 1){ // disable confirmButton when clicked
            confirmButton1.SetActive(false);
            waitButton.SetActive(false);
            buttonClicked = false;
            showBar = false;
            normalButton1.SetActive(true);
            combinationNum = 0;
            phase = 2;
        }
        if (buttonClicked && phase == 2 && subPhase == 1){
            normalButton1.SetActive(false);
            buttonClicked = false;
            keyButton2.SetActive(true);
            subPhase ++;
        }
        if (keyButtonClicked && phase == 2){
            keyButton2.SetActive(false);
            waitButton.SetActive(true);
            unlockMode = true;
            keyButtonClicked = false;
            showBar = true;
        }
        if (buttonClicked && phase == 2 && subPhase == 2){ // disable confirmButton when clicked
            confirmButton2.SetActive(false);
            waitButton.SetActive(false);
            buttonClicked = false;
            showBar = false;
            phase = 3;
            subPhase = 1;
            print("done");
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
        progressBar.transform.localScale = Vector3.Lerp(progressBar.transform.localScale, pBTargetScale, barSmooth); // progress bar increase for an amount based on the combinations made and combination required
        if (pBFullXScale - progressBar.transform.localScale.x < 0.1f && unlockMode){ // when progress bar is increased enough show confirmButton, disable unlockMode
            progressBar.transform.localScale = pBTargetScale;
            
            if (phase == 1){
                confirmButton1.SetActive(true);
            }
            else if (phase == 2){
                confirmButton2.SetActive(true);
            }
            unlockMode = false;
        }
    }
}

// set up an array to store which type of button to display: 0 for normal; 1 for key
// show the next button when confirmButton is clicked