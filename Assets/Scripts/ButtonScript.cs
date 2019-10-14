using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript : MonoBehaviour
{
    public Material buttonUp;
    public Material buttonDown;
    public MeshRenderer myMR;
    public bool Down = false;

    private void Update() {
        myMR = GetComponent<MeshRenderer>();
        if (Down){
            myMR.material = buttonDown;
        }
        else if (!Down){
            myMR.material = buttonUp;
        }
    }
}