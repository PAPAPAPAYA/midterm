using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when an object is dragged onto another, combine message is printed, dragged object returns to default pos
public class ObjectCombineScript : MonoBehaviour
{
    // bunch of bools to indicate which two objects are combining

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Zippo"){ // igdNum = 1
            CombineManagerScript.me.PassIngredient(1); // tell CombineManagerScript which ingredient is combing
        }
        if (other.gameObject.name == "mug"){ // igdNum = 2
            CombineManagerScript.me.PassIngredient(2);
        }
        if (other.gameObject.name == "phone"){ // igdNum = 3
            CombineManagerScript.me.PassIngredient(3);
        }
        if (other.gameObject.name == "pen"){ // igdNum = 4
            CombineManagerScript.me.PassIngredient(4);
        }
        if (other.gameObject.name == "paper"){ // igdNum = 5
            CombineManagerScript.me.PassIngredient(5);
        }
        if (other.gameObject.name == "jbl"){ // igdNum = 6
            CombineManagerScript.me.PassIngredient(6);
        }
        if (other.gameObject.name == "water boiler"){ // igdNum = 7
            CombineManagerScript.me.PassIngredient(7);
        }
        if (other.gameObject.name == "seven star"){ // igdNum = 8
            CombineManagerScript.me.PassIngredient(8);
        }
    }
}
