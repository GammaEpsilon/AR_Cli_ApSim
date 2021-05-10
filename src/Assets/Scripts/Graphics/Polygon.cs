using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon
{
    public Vector2[] points;
    public string identifier;
    public Polygon(Vector2[] pointList, string id) {
        points = pointList;
        identifier = id;
    }
    public void draw(LineRenderer lineRenderer) {
        int numPoints = points.Length;
        Vector3[] newPositions = new Vector3[numPoints];
        for(int i = 0; i < numPoints; i++) {
            // Vector2 newPoint = Coordinate.convert(points[i],center);
            // newPositions[i] = new Vector3(newPoint.x * scaling * 10, newPoint.y * scaling * 10, -0.001f);
            newPositions[i] = MapData.convert(points[i]) * 10 + new Vector3(0,0,-0.001f);
        }
        lineRenderer.positionCount = numPoints;
        lineRenderer.SetPositions(newPositions);
    }
}
