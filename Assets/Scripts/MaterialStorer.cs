using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStorer : MonoBehaviour
{
    public Material glow;
    public Material defaultMat;
    public bool glowing = false;
    public bool active = false;

    void Update()
    {
        if (active){
            print("activated");
        }
        if (glowing){
            GetComponent<MeshRenderer>().material = glow;
        }
        else{
            GetComponent<MeshRenderer>().material = defaultMat;
        }
    }
}
