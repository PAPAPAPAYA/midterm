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
    public bool igdScreen = false;
    public string combineText;

    public TextMeshProUGUI myText;

    public GameObject screen;
    public float throwFactor;
    public GameObject lightedCig;
    public AudioSource jblMusic;

    static public CombineManagerScript me;
    private void Awake() {
        me = this;
    }

    private void ThrowThings(string objectName){
        print("throw");
        GameObject.Find(objectName).gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GameObject.Find(objectName).gameObject.GetComponent<Rigidbody>().AddForce((screen.transform.position - GameObject.Find(objectName).transform.position) * throwFactor);
    }

    ///////////////////////////////////////////////////////////////////// do the combination
    private void Update() {
        

        if (combineText.Length > 4 && !GameManagerScript.me.gameOver && !GameManagerScript.me.waitDone){
            RaycastPointNClick.me.textToBeDisplayed = combineText;
        }
        
        if (!igdScreen){
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdMug){
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdZippo){
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdPaper){
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdPen){
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdCig){
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdPhone){
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (!igdJbl){
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }


        /////////////////////////// screen
        if (igdScreen && igdMug){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdMug = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("mug");
        }
        if (igdScreen && igdPhone){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdPhone = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("phone");
        }
        if (igdScreen && igdPaper){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdPaper = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("paper");
        }
        if (igdScreen && igdZippo){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdZippo = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("Zippo");
        }
        if (igdScreen && igdPen){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdPen = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("pen");
        }
        if (igdScreen && igdCig){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdCig = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("seven star");
        }
        if (igdScreen && igdJbl){
            combineText = "The screen is craked. I am feeling happier.";
            GameManagerScript.me.combinationNum ++;
            igdScreen = false;
            igdJbl = false;
            GameObject.Find("ScreenFrame").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
            ThrowThings("jbl");
        }



        ///////////////////// zippo
        if (igdZippo && igdMug){
            combineText = "The cotton is now wet. Can't use the Zippo for now.";
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.wetZippo = true;
            igdZippo = false;
            igdMug = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdPhone){
            combineText = ("i can't do that with Zippo and phone");
            igdZippo = false;
            igdPhone = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
        } 
        if (igdZippo && igdPaper && !RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.wetZippo && !RaycastPointNClick.me.burntPaper){
            combineText = ("The handout is burnt.");
            GameObject.Find("paper").GetComponent<MaterialStorer>().defaultMat = GameObject.Find("paper").GetComponent<MaterialStorer>().burntMat;
            GameObject.Find("paper").GetComponent<MaterialStorer>().glow = GameObject.Find("paper").GetComponent<MaterialStorer>().burnMatGlow;
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.burntPaper = true;
            igdZippo = false;
            igdPaper = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdPaper && !RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.wetZippo){
            combineText = ("Can't burn the handout with wet cotten.");
            igdZippo = false;
            igdPaper = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdPaper && RaycastPointNClick.me.wetPaper){
            combineText = ("The handout is wet. I can't burn it. Still need to complete it later.");
            igdZippo = false;
            igdPaper = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdPaper && RaycastPointNClick.me.burntPaper){
            combineText = ("The handout is already burnt.");
            igdZippo = false;
            igdPaper = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdPaper && RaycastPointNClick.me.burntWetPaper){
            combineText = ("The handout is already a mess.");
            igdZippo = false;
            igdPaper = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdPen){
            combineText = ("I can't do that with Zippo and pen.");
            igdZippo = false;
            igdPen = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdCig && RaycastPointNClick.me.lightedCig){
            combineText = ("I am already smoking one.");
            igdZippo = false;
            igdCig = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdCig && !RaycastPointNClick.me.wetCig){
            combineText = ("The cigarette is lighted.");
            lightedCig.gameObject.SetActive(true);
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.lightedCig = true;
            igdZippo = false;
            igdCig = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdCig && RaycastPointNClick.me.wetCig){
            combineText = ("I can't light up a wet cigarette.");
            igdZippo = false;
            igdCig = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdZippo && igdJbl){
            combineText = ("I can't do that with Zippo and jbl.");
            igdZippo = false;
            igdJbl = false;
            GameObject.Find("Zippo").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        ///////////////////// mug
        if (igdMug && igdPhone && RaycastPointNClick.me.brokenPhone){
            combineText = ("My phone is already broken.");
            igdMug = false;
            igdPhone = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
        } 
        if (igdMug && igdPhone){
            combineText = ("My phone is now broken.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.brokenPhone = true;
            jblMusic.Pause();
            igdMug = false;
            igdPhone = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
        }  
        if (igdMug && igdPen){
            combineText = ("I can't do anything with mug and pen.");
            igdMug = false;
            igdPen = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
        }  

        if (igdMug && igdPaper && RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper && !RaycastPointNClick.me.burntWetPaper){
            combineText = ("The handout is already wet.");
            igdMug = false;
            igdPaper = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }  
        if (igdMug && igdPaper && !RaycastPointNClick.me.burntPaper && !RaycastPointNClick.me.wetPaper){
            combineText = ("The handout is now wet.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.wetPaper = true;
            igdMug = false;
            igdPaper = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        } 
        if (igdMug && igdPaper && RaycastPointNClick.me.burntPaper && !RaycastPointNClick.me.burntWetPaper){
            combineText = ("The handout is now a mess.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.burntWetPaper = true;
            igdMug = false;
            igdPaper = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }  
        if (igdMug && igdPaper && RaycastPointNClick.me.burntWetPaper){
            combineText = ("The handout is already a mess.");
            igdMug = false;
            igdPaper = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        } 

        if (igdMug && igdJbl && RaycastPointNClick.me.brokenJBL){
            combineText = ("my JBL player is already broken.");
            igdMug = false;
            igdJbl = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdMug && igdJbl){
            combineText = ("my JBL player is now broken.");
            jblMusic.Pause();
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.brokenJBL = true;
            igdMug = false;
            igdJbl = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }

        if (igdMug && igdCig && RaycastPointNClick.me.wetCig){
            combineText = ("The cigarettes are already wet.");
            RaycastPointNClick.me.wetCig = true;
            igdMug = false;
            igdCig = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdMug && igdCig){
            combineText = ("The cigarettes are all wet, can't smoke them anymore.");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.wetCig = true;
            igdMug = false;
            igdCig = false;
            GameObject.Find("mug").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        ////////////////////// phone
        if (igdPhone && igdPen){
            combineText = ("I can't do that with phone and pen.");
            igdPhone = false;
            igdPen = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdPaper){
            combineText = ("I can't do that with phone and my handout.");
            igdPhone = false;
            igdPaper = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdCig){
            combineText = ("i can't do that with phone and cigarette");
            igdCig = false;
            igdPhone = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdJbl && RaycastPointNClick.me.brokenJBL && RaycastPointNClick.me.brokenPhone){
            combineText = ("Both my phone and my JBL are broken. What have I done.");
            igdJbl = false;
            igdPhone = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdJbl && RaycastPointNClick.me.onJBL){
            combineText = ("Music is already playing.");
            igdJbl = false;
            igdPhone = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdJbl && !RaycastPointNClick.me.brokenJBL && !RaycastPointNClick.me.brokenPhone){
            combineText = ("Music playing.");
            GameManagerScript.me.combinationNum ++;
            //RaycastPointNClick.me.onJBL = true;
            jblMusic.Play(0);
            igdJbl = false;
            igdPhone = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdJbl && RaycastPointNClick.me.brokenJBL && !RaycastPointNClick.me.brokenPhone){
            combineText = ("The JBL is still broken.");
            igdJbl = false;
            igdPhone = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPhone && igdJbl && !RaycastPointNClick.me.brokenJBL && RaycastPointNClick.me.brokenPhone){
            combineText = ("My phone is still broken.");
            igdJbl = false;
            igdPhone = false;
            GameObject.Find("phone").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        
        /////////////////////// pen
        if (igdPen && igdPaper && !RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
           combineText = ("The handout is completed");
            GameManagerScript.me.combinationNum ++;
            RaycastPointNClick.me.completedPaper = true;
            igdPaper = false;
            igdPen = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPen && igdPaper && RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
            combineText = ("The handout is wet. Maybe later.");
            igdPaper = false;
            igdPen = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPen && igdPaper && RaycastPointNClick.me.burntWetPaper){
            combineText = ("The handout is a mess. Can't write on this mess.");
            igdPaper = false;
            igdPen = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPen && igdPaper && !RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
            combineText = ("The handout is burnt. Can't write on this thing.");
            igdPaper = false;
            igdPen = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPen && igdPaper && RaycastPointNClick.me.completedPaper){
            combineText = ("The handout is already completed.");
            igdPaper = false;
            igdPen = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPen && igdCig){
            combineText = ("i can't do that with pen and cigarette");
            igdPen = false;
            igdCig = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdPen && igdJbl){
            combineText = ("i can't do that with pen and jbl");
            igdPen = false;
            igdJbl = false;
            GameObject.Find("pen").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        //////////////////////// seven star
        if (igdCig && igdJbl){
            combineText = ("I can't do that with cigarette and jbl.");
            igdCig = false;
            igdJbl = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("jbl").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        if (igdCig && igdPaper){
           combineText = ("I can't do that with cigarette and my handout.");
            igdCig = false;
            igdPaper = false;
            GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
            GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        }
        // if (igdCig && igdPaper && !RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
        //    combineText = ("the handout is now burnt");
        //     RaycastPointNClick.me.burntPaper = true;
        //     GameManagerScript.me.combinationNum ++;
        //     igdCig = false;
        //     igdPaper = false;
        //     GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        //     GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        // }
        // if (igdCig && igdPaper && RaycastPointNClick.me.wetPaper && !RaycastPointNClick.me.burntPaper){
        //     combineText = ("The handout is wet. Can't burn it.");
        //     igdCig = false;
        //     igdPaper = false;
        //     GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        //     GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        // }
        // if (igdCig && igdPaper && RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
        //     combineText = ("The handout is already a mess.");
        //     igdCig = false;
        //     igdPaper = false;
        //     GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        //     GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        // }
        // if (igdCig && igdPaper && !RaycastPointNClick.me.wetPaper && RaycastPointNClick.me.burntPaper){
        //     combineText = ("The handout is already burnt.");
        //     igdCig = false;
        //     igdPaper = false;
        //     GameObject.Find("seven star").gameObject.GetComponent<MaterialStorer>().selected = false;
        //     GameObject.Find("paper").gameObject.GetComponent<MaterialStorer>().selected = false;
        // }
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
            igdScreen = true;
        }
    }
}
