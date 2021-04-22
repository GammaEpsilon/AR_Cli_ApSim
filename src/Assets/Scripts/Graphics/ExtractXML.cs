using System;
using System.Xml;
using System.Collections;
using System.Linq;
using UnityEngine;
public static class ExtractXML    
{
    public static double[][][] getShapes(string path) {
        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = true;
        try{
            doc.Load(path);
            Debug.Log("Map loaded");
        }
        catch (System.IO.FileNotFoundException e){
            Debug.Log(e);
            Debug.Log("No map found :(");
        }
        
        XmlNode root = doc.DocumentElement;

        XmlNodeList polygons = root.SelectNodes("//root/identifiables/scenario/map/shapes");

        double[][][] map = new double[polygons.Count][][];
        int l = 0;
        char[] delims = new[] { '\r', '\n' };
        foreach(XmlNode polygon in polygons){
            XmlNodeList points = polygon.SelectNodes("./curves/p1");
            ArrayList cords = new ArrayList();
            foreach (XmlNode point in points){
                
                string[] strings = point.InnerText.Split(delims, StringSplitOptions.RemoveEmptyEntries);
        
                foreach(string s in strings){
                    if(s.Trim()!="" | s.Trim()!="\n" | s.Trim()!=" "){
                        cords.Add(s.Trim());
                    }
                }
            }   
            string[] arr = (string[]) cords.ToArray( typeof( string ) );
            arr = arr.Where(x => x != string.Empty).ToArray();
            int k = 0;
            double[][] coordinates = new double[arr.Length/2][];
            for(int i = 0; i < arr.Length-1; i++){
                //Add coordinates to array, removes empty line
                if(i % 2 == 0){
                    double[] coord = new double[2];
                    coord[0] = Convert.ToDouble(arr[i],System.Globalization.CultureInfo.InvariantCulture);
                    coord[1] = Convert.ToDouble(arr[i+1],System.Globalization.CultureInfo.InvariantCulture);
                    coordinates[k] = coord;
                    k++;
                }
            }
        
            //Add polygon to array of polygons
            map[l] = coordinates;
            l++;
        }
        return map;
    }
}