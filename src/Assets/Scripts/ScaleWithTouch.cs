using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithTouch : MonoBehaviour
{
    // Start is called before the first frame update

    float prevDiff, currDiff, zoomMod;
    Vector2 firstPrevPos, secondPrevPos;

    float zoomModifierSpeed = 0.001f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2) {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            firstPrevPos = firstTouch.position - firstTouch.deltaPosition;
            secondPrevPos = secondTouch.position - secondTouch.deltaPosition;

            prevDiff = (firstPrevPos-secondPrevPos).magnitude;
            currDiff = (firstTouch.position-secondTouch.position).magnitude;

            zoomMod = (currDiff-prevDiff)*zoomModifierSpeed;
            transform.localScale += new Vector3(zoomMod,zoomMod,zoomMod);


        }
    }
}
