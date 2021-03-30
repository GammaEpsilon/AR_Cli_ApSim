using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbols : MonoBehaviour
{
    // Gameobjects for symbols
    public GameObject hostileMedicalPrefab;
    public GameObject mechanizedInfantryPrefab;


    // Start is called before the first frame update
    void Start()
    {
        placeOnCoordinates(0, 0, 0, hostileMedicalPrefab);
        placeOnCoordinates(0.03f, 0, 0, mechanizedInfantryPrefab);
    }

    // Specify coordinates and gameobject to place
    public void placeOnCoordinates(float x, float y, float z, GameObject symbol)
    {
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(symbol, pos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
