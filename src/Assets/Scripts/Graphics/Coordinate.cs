using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
    public static Vector2 convert(Vector2 coord, Vector2 center) {
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
        return new Vector2(x,y);
    }
}
