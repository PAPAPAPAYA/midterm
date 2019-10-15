using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    static public CombineManagerScript me;
    private void Awake() {
        me = this;
    }



    ///////////////////////////////////////////////////////////////////// do the combination
    private void Update() {
        ///////////////////// zippo
        if (igdZippo && igdMug){
            print("the cotton is now wet, can't use the zippo for now");
            GameManagerScript.me.combinationNum ++;
            igdZippo = false;
            igdMug = false;
            //RaycastPointNClick.me.putBackObject = true;
        }
        if (igdZippo && igdPhone){
            print("i can't do that with zippo and phone");
            igdZippo = false;
            igdPhone = false;
            //RaycastPointNClick.me.putBackObject = true;
        } 
        if (igdZippo && igdPaper){
            print("the handout is burnt");
            GameManagerScript.me.combinationNum ++;
            igdZippo = false;
            igdPaper = false;
        }  
        if (igdZippo && igdPen){
            print("i can't do that with zippo and pen");
            igdZippo = false;
            igdPen = false;
        }
        if (igdZippo && igdCig){
            print("the cigarette is lighted");
            GameManagerScript.me.combinationNum ++;
            igdZippo = false;
            igdCig = false;
        } 
        if (igdZippo && igdJbl){
            print("i can't do that with zippo and jbl");
            igdZippo = false;
            igdJbl = false;
        }
        ///////////////////// mug
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            GameManagerScript.me.combinationNum ++;
            igdMug = false;
            igdPhone = false;
        }  
        if (igdMug && igdPen){
            print("i can't do that with mug and pen.");
            igdMug = false;
            igdPen = false;
        }  
        if (igdMug && igdPaper){
            print("the paper is now wet");
            GameManagerScript.me.combinationNum ++;
            igdMug = false;
            igdPaper = false;
        }  
        if (igdMug && igdJbl){
            print("my JBL player is now broken");
            GameManagerScript.me.combinationNum ++;
            igdMug = false;
            igdJbl = false;
        }
        if (igdMug && igdCig){
            print("the cigarettes are all wet, can't smoke them anymore");
            GameManagerScript.me.combinationNum ++;
            igdMug = false;
            igdCig = false;
        }
        ////////////////////// phone
        if (igdPhone && igdPen){
            print("i can't do that with phone and pen");
            igdPhone = false;
            igdPen = false;
        }
        if (igdPhone && igdPaper){
            print("i can't do that with phone and my handout");
            igdPhone = false;
            igdPaper = false;
        }
        if (igdPhone && igdCig){
            print("i can't do that with phone and cigarette");
            igdCig = false;
            igdPhone = false;
        }
        if (igdPhone && igdJbl){
            print("music playing");
            GameManagerScript.me.combinationNum ++;
            igdJbl = false;
            igdPhone = false;
        }
        /////////////////////// pen
        if (igdPen && igdPaper){
            print("the handout is completed");
            GameManagerScript.me.combinationNum ++;
            igdPaper = false;
            igdPen = false;
        }
        if (igdPen && igdCig){
            print("i can't do that with pen and cigarette");
            igdPen = false;
            igdCig = false;
        }
        if (igdPen && igdJbl){
            print("i can't do that with pen and jbl");
            igdPen = false;
            igdJbl = false;
        }
        //////////////////////// seven star
        if (igdCig && igdJbl){
            print("i can't do that with cigarette and jbl");
            igdCig = false;
            igdJbl = false;
        }
        if (igdCig && igdPaper){
            print("the handout is now burnt");
            GameManagerScript.me.combinationNum ++;
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
