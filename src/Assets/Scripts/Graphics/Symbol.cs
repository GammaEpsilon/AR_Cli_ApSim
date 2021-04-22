using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol
{
    public Vector2 coord;
    public string code;

    void draw() {
        Vector3 unityPos = MapData.convert(coord);
        //Do Stuff
    }

}
