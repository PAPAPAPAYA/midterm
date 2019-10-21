using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStorer : MonoBehaviour
{
    public Material glow;
    public Material defaultMat;
    public bool glowing = false;
    public bool isScreenFrame = false;
    public bool screenCanBeSelected = false;
    public bool selected = false;

    public Material burntMat;
    public Material burnMatGlow;
    public Material completedMat;
    public Material completedMatGlow;

    void Update()
    {
        if (selected && !isScreenFrame){
            GetComponent<MeshRenderer>().material = glow;
        }
        if (glowing && !isScreenFrame){
            GetComponent<MeshRenderer>().material = glow;
        }
        if (selected && isScreenFrame && screenCanBeSelected){
            GetComponent<MeshRenderer>().material = glow;
        }
        if (glowing && isScreenFrame && screenCanBeSelected){
            GetComponent<MeshRenderer>().material = glow;
        }
        if (!selected && !glowing && !isScreenFrame){
            GetComponent<MeshRenderer>().material = defaultMat;
        }
        if (!selected && !glowing && isScreenFrame && screenCanBeSelected){
            GetComponent<MeshRenderer>().material = defaultMat;
        }



        if (GameManagerScript.me.phase == 3 && GameManagerScript.me.unlockMode){ // in this ending phase screen can be selected
            if (isScreenFrame){
                screenCanBeSelected = true;
            }
        }
    }
}
