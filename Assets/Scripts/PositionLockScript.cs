using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLockScript : MonoBehaviour
{
    Vector3 originalPos;
    Quaternion originalAngle;
    public GameObject defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        originalAngle = transform.rotation;
        originalPos = defaultPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = originalAngle;
        
    }
    void   LateUpdate() {
        transform.position = defaultPos.transform.position;
    }
}
