using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStorer : MonoBehaviour
{
    public Material glow;
    public Material defaultMat;
    public bool glowing = false;
    public bool isScreenFrame = false;
    public bool selected = false;

    void Update()
    {
        if (selected){
            GetComponent<MeshRenderer>().material = glow;
        }
        if (isScreenFrame){
            print("only active at the ending");
        }
        if (glowing){
            GetComponent<MeshRenderer>().material = glow;
        }
        else if (!selected && !glowing){
            GetComponent<MeshRenderer>().material = defaultMat;
        }
    }
}
