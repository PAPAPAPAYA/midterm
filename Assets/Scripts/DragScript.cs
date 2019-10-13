using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    public Vector3 mOffset;

    private float mZCoord;
    public bool dragActive;

    //public GameObject objectDefaultPos;

    void OnMouseDown(){
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos(){
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // void OnMouseDrag(){
    //     if (dragActive){
    //         transform.position = GetMouseWorldPos() + mOffset;
    //     }
    // }

    private void Update() {
        // if (Input.GetMouseButtonDown(0)){
        //     objectDefaultPos.transform.position = transform.position;
        // }
        if (Input.GetMouseButton(0)){
            
            transform.position = GetMouseWorldPos() + mOffset;
        }
        else if (Input.GetMouseButtonUp(0)){
            //transform.position = RaycastPointNClick.me.objectDefaultPos.transform.position;
        }
    }
}