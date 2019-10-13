using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragTest : MonoBehaviour
{
    public float lerpNum;
    public Transform objectDefaultPos;
    private GameObject tempObject;
    private float zToBeClamped;
    private float yToBeClamped;
    private bool draggingObject =false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // STEP 1: declare a ray, use mouse's screenspace pixel coordinate
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // STEP 2: declare mouse ray distance
        float mouseRayDist = 10000f;

        // STEP 2B: declare a blank RaycastHit variable
        RaycastHit rayHit = new RaycastHit();

        // STEP 3: debug draw the raycast
        Debug.DrawRay(mouseRay.origin,mouseRay.direction * mouseRayDist, Color.magenta);

        // STEP 4: shoot the raycast
        if (Physics.Raycast(mouseRay, out rayHit, mouseRayDist)){
            if (Input.GetMouseButtonDown(0) && rayHit.collider.gameObject.layer == 9){
                tempObject = rayHit.collider.gameObject;
                objectDefaultPos.position = rayHit.collider.gameObject.transform.position;
                draggingObject = true;
            }
            if (Input.GetMouseButton(0) && rayHit.collider.gameObject.layer == 9){
                rayHit.transform.position = rayHit.point; // set sphere to raycast hit impact world position
                yToBeClamped = 0.8f;
                zToBeClamped = Mathf.Clamp(rayHit.transform.position.z,-8.97f,-8.2f);
                rayHit.transform.position = new Vector3 (rayHit.transform.position.x,yToBeClamped, zToBeClamped);
            }
            if (Input.GetMouseButtonUp(0) && rayHit.collider.gameObject.layer == 9){
                //tempObject.transform.position = Vector3.Lerp(tempObject.transform.position,objectDefaultPos.position,lerpNum);
                draggingObject = false;
                //tempObject = null;
            }
        }
        if (!draggingObject && tempObject != null){
            tempObject.transform.position = Vector3.Lerp(tempObject.transform.position,objectDefaultPos.position,lerpNum);
        }
    }
}