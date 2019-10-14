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
        if (igdZippo && igdMug){
            print("i can't do that with zippo and mug.");
            igdZippo = false;
            igdMug = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdZippo && igdPhone){
            print("i can't do that with zippo and phone");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
        }
        if (igdMug && igdPhone){
            print("my phone is now broken.");
            igdZippo = false;
            igdPhone = false;
            RaycastPointNClick.me.putBackObject = true;
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
