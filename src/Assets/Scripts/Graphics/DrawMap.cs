using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMap : MonoBehaviour
{
    // Start is called before the first frame update
    public string scenarioFileName;
    void Start() {
        Debug.Log("Trying to fetch XML");
        double[][][] shapes = ExtractXMLMap.getShapes(scenarioFileName);
        MilitaryUnit[] units = ExtractXMLUnits.getUnits(scenarioFileName);
        Debug.Log("Xml loaded");

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

        float minLong = Mathf.Infinity;
        float maxLong = -minLong;
        float maxLat = maxLong;
        float minLat = minLong;

        foreach (Polygon p in polygonList) {
            foreach (Vector2 c in p.points) {
                if (c.x < minLong) {
                    minLong = c.x;
                }
                if (c.x > maxLong) {
                    maxLong = c.x;
                }
                if (c.y < minLat) {
                    minLat = c.y;
                }
                if (c.y > maxLat) {
                    maxLat = c.y;
                }
            }
        }

        Debug.Log((minLong,maxLong));
        Debug.Log((minLat,maxLat));
        Debug.Log("\n");

        foreach (MilitaryUnit u in units) {
            Debug.Log((u.Lon,u.Lat));
            if (u.Lon < minLong) {
                minLong = (float)u.Lon;
            }
            if (u.Lon > maxLong) {
                maxLong = (float)u.Lon;
            }
            if (u.Lat < minLat) {
                minLat = (float)u.Lat;
            }
            if (u.Lat > maxLat) {
                maxLat = (float)u.Lat;
            }
        }

        Vector2 center = new Vector2((maxLong+minLong)/2,(maxLat+minLat)/2);
        Vector2 scalingCoords = Coordinate.convert(new Vector2(maxLong,maxLat), center) - Coordinate.convert(new Vector2(minLong,minLat), center);
        float scaling = 1f/Mathf.Max(scalingCoords.x,scalingCoords.y);

        MapData.scaling = scaling;
        MapData.center = center;

        // Draw polygons
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
            lr.transform.SetPositionAndRotation(transform.position,transform.rotation);
            g.transform.localScale = Vector3.one / 10f;
            p.draw(lr);
        }
        
        // Draw symbols
        foreach (MilitaryUnit unit in units) {
            Symbols.createSymbolFromMilitaryUnit(unit);
        }
        
    }
}
