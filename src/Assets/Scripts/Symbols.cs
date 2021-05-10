using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public static class Symbols
{
    private static GameObject map = GameObject.Find("/MapPlacement/Map");
    public static void createSymbolFromMilitaryUnit(MilitaryUnit unit) {
        string id = unit.SymbolID;
        float lon = (float)unit.Lon;
        float lat = (float)unit.Lat;
        Vector3 converted = MapData.convert(new Vector2(lon,lat));
        createSymbol(new Vector3(converted.x,converted.y,0),"Test1");
    }
    public static void createSymbol(Vector3 pos, string id) {
        GameObject symbol = new GameObject("Symbol");
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    
        Texture tex = Resources.Load<Texture2D>(id);

        Material quadMaterial = new Material(Shader.Find("Unlit/Transparent"));
        quadMaterial.mainTexture = tex;
        quadMaterial.renderQueue += 1; // Make symbol appear in front of map rather than behind

        Renderer quadRenderer = quad.GetComponent<Renderer>();
        quadRenderer.material = quadMaterial;

        Material cylMaterial = new Material(Shader.Find("Unlit/Color"));
        cylMaterial.color = Color.red;

        cylinder.GetComponent<Renderer>().material = cylMaterial;

        float quadY = 0.1f;
        float quadScale = 0.05f;
        float cylWidth = 0.004f;
        float cylHeight = quadY/2f - quadRenderer.bounds.size.y * quadScale * .25f;
        float cylY = cylHeight;

        quad.transform.localScale = Vector3.one * quadScale;
        cylinder.transform.localScale = new Vector3(cylWidth, cylHeight, cylWidth);

        cylinder.transform.Translate(new Vector3(0,cylY,0));
        quad.transform.Translate(new Vector3(0,quadY,0));

        symbol.transform.SetParent(map.transform,false);
        quad.transform.SetParent(symbol.transform,false);
        cylinder.transform.SetParent(symbol.transform,false);

        symbol.transform.Rotate(new Vector3(-90,0,0));
        symbol.transform.localPosition = pos;

        symbol.AddComponent<TurnToCamera>(); // Make symbol face the camera

    }

    // Specify coordinates and gameobject to place
    public static void placeOnCoordinates(Vector3 pos, GameObject symbol)
    {
        //Vector3 cylinderPos = new Vector3(transform.position.x, someNewYValue, transform.position.z);
        //transform.position = newPosition;
        GameObject map = GameObject.Find("/MapPlacement/Map");
        //cylinder.transform.SetParent(parent.transform, false);
        //GameObject newSymbol = GameObject.Instantiate(symbol, pos, Quaternion.identity);
        symbol.transform.SetParent(map.transform,false);
        symbol.transform.Rotate(new Vector3(-90,0,0));
        //Instantiate(cylinder, pos, Quaternion.identity);
    }
}
