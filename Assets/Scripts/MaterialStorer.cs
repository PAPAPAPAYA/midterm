using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStorer : MonoBehaviour
{
    public Material glow;
    public Material defaultMat;
    public bool glowing = false;
    public bool isScreenFrame = false;

    void Update()
    {
        if (isScreenFrame){
            print("only active at the ending");
        }
        if (glowing){
            GetComponent<MeshRenderer>().material = glow;
        }
        else{
            GetComponent<MeshRenderer>().material = defaultMat;
        }
    }
}
