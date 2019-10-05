using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    static public GameManagerScript me;
    public GameObject clickButton;
    public GameObject waitButton;
    public bool buttonClicked = false;
    
    private void Awake() {
        me = this;
    }

    private void Update() {
        if (buttonClicked){
            clickButton.SetActive(false);
            waitButton.SetActive(true);
        }
    }

}
