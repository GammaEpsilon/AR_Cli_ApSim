using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTouch : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 0.001f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch t = Input.GetTouch(0);
        if(Input.touchCount == 1 && t.phase == TouchPhase.Moved) {
            Vector2 diff = t.deltaPosition;
            //Transform camT = Camera.current.transform;
            transform.position += new Vector3(diff.x,0,diff.y)*moveSpeed;
            //transform.position += diff.x*transform.right*moveSpeed;
            //transform.position += diff.y*transform.forward*moveSpeed;
        }
    }
}
