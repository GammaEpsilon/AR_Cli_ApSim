using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMap : MonoBehaviour
{
    // Start is called before the first frame update
    public string scenarioFileName;
    void Start() {
        string path = "Assets/Scenarios/"+scenarioFileName+".scn";
        double[][][] shapes = ExtractXML.getShapes(path);

        // foreach(double[][] shape in shapes){
        //     Debug.Log("[");
        //     foreach(double[] c in shape) {
        //         Debug.Log("(");
        //         Debug.Log(c[0]);
        //         Debug.Log(c[1]);
        //         Debug.Log(")");
        //     }
        //     Debug.Log("]");
        // }

        int numShapes = shapes.Length;
        Polygon[] polygonList = new Polygon[numShapes];

        for (int i = 0; i < numShapes; i++) {
            double[][] coords = shapes[i];
            int numPoints = coords.GetLength(0);
            Vector2[] pointList = new Vector2[numPoints];
            for (int j = 0; j < numPoints; j++) {
                pointList[j] = new Vector2((float) coords[j][0],(float) coords[j][1]);
            }
            polygonList[i] = new Polygon(pointList,i.ToString());
        }

        float minX = Mathf.Infinity;
        float maxX = -minX;
        float maxY = maxX;
        float minY = minX;

        foreach (Polygon p in polygonList) {
            foreach (Vector2 c in p.points) {
                if (c.x < minX) {
                    minX = c.x;
                }
                if (c.x > maxX) {
                    maxX = c.x;
                }
                if (c.y < minY) {
                    minY = c.y;
                }
                if (c.y > maxY) {
                    maxY = c.y;
                }
            }
        }

        Vector2 center = new Vector2((maxX+minX)/2,(maxY+minY)/2);
        Vector2 scalingCoords = Coordinate.convert(new Vector2(maxX,maxY), center) - Coordinate.convert(new Vector2(minX,minY), center);
        float scaling = 1f/Mathf.Max(scalingCoords.x,scalingCoords.y);

        MapData.scaling = scaling;
        MapData.center = center;

        for (int i = 0; i < polygonList.Length; i++) {
            Polygon p = polygonList[i];
            GameObject g = new GameObject("Polygon " + i.ToString());
            g.transform.parent = transform;
            LineRenderer lr = g.AddComponent<LineRenderer>();
            lr.alignment = LineAlignment.TransformZ;
            Material m = new Material(Shader.Find("Unlit/Color"));
            m.color = Color.black;
            lr.material = m;
            lr.loop = true;
            lr.transform.localEulerAngles = Vector3.zero;
            lr.useWorldSpace = false;
            lr.widthMultiplier = 0.075f;
            g.transform.localScale = Vector3.one / 10f;
            p.draw(lr);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
