using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2) {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            if(firstTouch.phase == TouchPhase.Moved || secondTouch.phase == TouchPhase.Moved) {
                Vector2 prevFirst = firstTouch.position-firstTouch.deltaPosition;
                Vector2 prevSecond = secondTouch.position-secondTouch.deltaPosition;
                float pdx = prevFirst.x-prevSecond.x;
                float pdy = prevFirst.y-prevSecond.y;
                float prevAngle = Mathf.Atan2(pdy,pdx);
                float dx = firstTouch.position.x-secondTouch.position.x;
                float dy = firstTouch.position.y-secondTouch.position.y;
                float newAngle = Mathf.Atan2(dy,dx);
                float dAngle = prevAngle-newAngle;


                transform.Rotate(new Vector3(0,dAngle*Mathf.Rad2Deg,0));

            }


        }
    }
}
