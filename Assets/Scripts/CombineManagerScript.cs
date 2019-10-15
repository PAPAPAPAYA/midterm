using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombineManagerScript : MonoBehaviour
{
    public bool igdZippo = false;
    public bool igdMug = false;
    public bool igdPhone = false;
    public bool igdPen = false;
    public bool igdPaper = false;
    public bool igdCig = false;
    public bool igdJbl = false;
    public bool igdWB = false;

    public TextMeshProUGUI myText;

    static public CombineManagerScript me;
    private void Awake() {
        me = this;
    }



    ///////////////////////////////////////////////////////////////////// do the combination
    private void Update() {
        ///////////////////// zippo
        if (igdZippo && igdMug){
            myText.text = "The cotton is now wet. Can't use the Zippo for now.";
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.wetZippo = true;
            igdZippo = false;
            igdMug = false;
        }
        if (igdZippo && igdPhone){
            myText.text = ("i can't do that with Zippo and phone");
            igdZippo = false;
            igdPhone = false;
        } 
        if (igdZippo && igdPaper && !RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.wetZippo){
            myText.text = ("The handout is burnt.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.burntPaper = true;
            igdZippo = false;
            igdPaper = false;
        }
        if (igdZippo && igdPaper && !RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.wetZippo){
            myText.text = ("Can't burn the handout with wet cotten.");
            igdZippo = false;
            igdPaper = false;
        }
        if (igdZippo && igdPaper && RaycastPointNClick.me.wetPaper){
            myText.text = ("The handout is wet. I can't burn it. Still need to complete it later.");
            igdZippo = false;
            igdPaper = false;
        }
        if (igdZippo && igdPen){
            myText.text = ("I can't do that with Zippo and pen.");
            igdZippo = false;
            igdPen = false;
        }
        if (igdZippo && igdCig && !RaycastPointNClick.me.wetCig){
            myText.text = ("The cigarette is lighted.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.lightedCig = true;
            igdZippo = false;
            igdCig = false;
        }
        if (igdZippo && igdCig && RaycastPointNClick.me.wetCig){
            myText.text = ("I can't light up a wet cigarette.");
            igdZippo = false;
            igdCig = false;
        }
        if (igdZippo && igdJbl){
            myText.text = ("I can't do that with Zippo and jbl.");
            igdZippo = false;
            igdJbl = false;
        }
        ///////////////////// mug
        if (igdMug && igdPhone){
            myText.text = ("My phone is now broken.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.brokenPhone = true;
            igdMug = false;
            igdPhone = false;
        }  
        if (igdMug && igdPen){
            myText.text = ("I can't do that with mug and pen.");
            igdMug = false;
            igdPen = false;
        }  
        if (igdMug && igdPaper && !RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is now wet.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.wetPaper = true;
            igdMug = false;
            igdPaper = false;
        } 
        if (igdMug && igdPaper && RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is now a mess.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.burntWetPaper = true;
            igdMug = false;
            igdPaper = false;
        }  
        if (igdMug && igdJbl){
            myText.text = ("my JBL player is now broken.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.brokenJBL = true;
            igdMug = false;
            igdJbl = false;
        }
        if (igdMug && igdCig){
            myText.text = ("The cigarettes are all wet, can't smoke them anymore.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.wetCig = true;
            igdMug = false;
            igdCig = false;
        }
        ////////////////////// phone
        if (igdPhone && igdPen){
            myText.text = ("I can't do that with phone and pen.");
            igdPhone = false;
            igdPen = false;
        }
        if (igdPhone && igdPaper){
            myText.text = ("I can't do that with phone and my handout.");
            igdPhone = false;
            igdPaper = false;
        }
        if (igdPhone && igdCig){
            myText.text = ("i can't do that with phone and cigarette");
            igdCig = false;
            igdPhone = false;
        }
        if (igdPhone && igdJbl && !RaycastPointNClick.me.brokenJBL && !RaycastPointNClick.me.brokenPhone){
            myText.text = ("music playing");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.onJBL = true;
            igdJbl = false;
            igdPhone = false;
        }
        if (igdPhone && igdJbl && RaycastPointNClick.me.brokenJBL && !RaycastPointNClick.me.brokenPhone){
            myText.text = ("The JBL is still broken.");
            igdJbl = false;
            igdPhone = false;
        }
        if (igdPhone && igdJbl && !RaycastPointNClick.me.brokenJBL && RaycastPointNClick.me.brokenPhone){
            myText.text = ("My phone is still broken.");
            igdJbl = false;
            igdPhone = false;
        }
        if (igdPhone && igdJbl && RaycastPointNClick.me.brokenJBL && RaycastPointNClick.me.brokenPhone){
            myText.text = ("Both my phone and my JBL are broken. What have I done.");
            igdJbl = false;
            igdPhone = false;
        }
        /////////////////////// pen
        if (igdPen && igdPaper && !RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is completed");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.completedPaper = true;
            igdPaper = false;
            igdPen = false;
        }
        if (igdPen && igdPaper && RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is wet. Maybe later.");
            igdPaper = false;
            igdPen = false;
        }
        if (igdPen && igdPaper && RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is a mess. Can't write on this mess.");
            igdPaper = false;
            igdPen = false;
        }
        if (igdPen && igdPaper && !RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is burnt. Can't write on this thing.");
            igdPaper = false;
            igdPen = false;
        }
        if (igdPen && igdPaper && RaycastPointNClick.me.completedPaper){
            myText.text = ("The handout is already completed.");
            igdPaper = false;
            igdPen = false;
        }
        if (igdPen && igdCig){
            myText.text = ("i can't do that with pen and cigarette");
            igdPen = false;
            igdCig = false;
        }
        if (igdPen && igdJbl){
            myText.text = ("i can't do that with pen and jbl");
            igdPen = false;
            igdJbl = false;
        }
        //////////////////////// seven star
        if (igdCig && igdJbl){
            myText.text = ("i can't do that with cigarette and jbl");
            igdCig = false;
            igdJbl = false;
        }
        if (igdCig && igdPaper && !RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
            myText.text = ("the handout is now burnt");
            RaycastPointNClick.me.burntPaper = true;
            GameManagerScript.me.combinationNum ++;
            igdCig = false;
            igdPaper = false;
        }
        if (igdCig && igdPaper && RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is wet. Can't burn it.");
            igdCig = false;
            igdPaper = false;
        }
        if (igdCig && igdPaper && RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is already a mess.");
            igdCig = false;
            igdPaper = false;
        }
        if (igdCig && igdPaper && !RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
            myText.text = ("The handout is already burnt.");
            igdCig = false;
            igdPaper = false;
        }
    }

    public void PassIngredient(int igdNum){
        if (igdNum == 1){
            igdZippo = true;
        }
        if (igdNum == 2){
            igdMug = true;
        }
        if (igdNum == 3){
            igdPhone = true;
        }
        if (igdNum == 4){
            igdPen = true;
        }
        if (igdNum == 5){
            igdPaper = true;
        }
        if (igdNum == 6){
            igdCig = true;
        }
        if (igdNum == 7){
            igdJbl = true;
        }
        if (igdNum == 8){
            igdWB = true;
        }
    }
}
