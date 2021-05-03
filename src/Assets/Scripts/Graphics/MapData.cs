using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapData {

    public static float scaling;
    public static Vector2 center; //in long and la

    public static Vector3 convert(Vector2 coord) { //coord is (long, lat)
        //Formula: https://mathworld.wolfram.com/LambertAzimuthalEqual-AreaProjection.html
        float phi = Mathf.Deg2Rad*coord.x;
        float lambda = Mathf.Deg2Rad*coord.y;
        float phi1 = Mathf.Deg2Rad*center.x;
        float lambda0 = Mathf.Deg2Rad*center.y;
        float cosPhi = Mathf.Cos(phi);
        float sinPhi = Mathf.Sin(phi);
        float cosPhi1 = Mathf.Cos(phi1);
        float sinPhi1 = Mathf.Sin(phi1);
        float cosLmL0 = Mathf.Cos(lambda-lambda0);
        float k = Mathf.Sqrt(2/(1+sinPhi1*sinPhi+cosPhi1*cosPhi*cosLmL0));
        float x = k*cosPhi*Mathf.Sin(lambda-lambda0);
        float y = k*(cosPhi1*sinPhi-sinPhi1*cosPhi*cosLmL0);
        return new Vector3(x*scaling,y*scaling,0);
    }
}