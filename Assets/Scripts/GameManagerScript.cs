using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    static public GameManagerScript me;
    public GameObject clickButton;
    public GameObject waitButton;
    public bool buttonClicked = false;
    public bool unlockMode = false;
    public int objectUnlockedNum = 0;
    
    private void Awake() {
        me = this;
    }

    private void Update() {
        if (buttonClicked){
            clickButton.SetActive(false);
            waitButton.SetActive(true);
            unlockMode = true;
            buttonClicked = false;
        }
        print(unlockMode);
    }

}

// after clicking button let player choose which object to unlock...done
// if object glows when cursor hovering over then unlockable...done
// click object to unlock object...done
