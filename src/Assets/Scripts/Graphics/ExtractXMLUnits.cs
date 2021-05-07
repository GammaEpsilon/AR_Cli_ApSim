using System;
using System.Xml;
using System.Collections;
using System.Globalization;
using System.Linq;
using UnityEngine;
public class ExtractXMLUnits {
    public static MilitaryUnit[] getUnits(string fileName){
        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = true;
        try{
            TextAsset textXml = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
            doc.LoadXml(textXml.text);
            Console.WriteLine("XML loaded");
        }
        catch (System.IO.FileNotFoundException){
            Console.WriteLine("No XML found :(");
        }
        
        XmlNode root = doc.DocumentElement;
        //XmlNodeList units = root.SelectNodes("//root/identifiables/scenario/militaryUnits");
        XmlNodeList units = root.SelectNodes("descendant::militaryUnits");
        //int counter = 1;
        int count = units.Count;
        MilitaryUnit[] unitsList = new MilitaryUnit[count];
        for (int i = 0; i < count; i++) {
            //Console.WriteLine(counter);
            //counter++;
            XmlNode unit = units[i];
            XmlNode currentNode = unit.SelectSingleNode("./present");
            XmlElement currentElement = (XmlElement)currentNode;
            bool present = bool.Parse(currentElement["value"].InnerText);
            //Console.WriteLine(present);

            currentNode = unit.SelectSingleNode("./location/radius");
            currentElement = (XmlElement)currentNode;
            double radius = double.Parse(currentElement["value"].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture);
            //Console.WriteLine(radius);

            currentNode = unit.SelectSingleNode("./location/center");
            currentElement = (XmlElement)currentNode;
            double lat = double.Parse(currentElement["lat"].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture);
            //Console.WriteLine(lat);
            double lon = double.Parse(currentElement["lon"].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture);
            //Console.WriteLine(lon);

            currentNode = unit.SelectSingleNode("./symbolIDCode");
            currentElement = (XmlElement)currentNode;
            string symbolID = currentElement["value"].InnerText;
            //Console.WriteLine(symbolID);

            MilitaryUnit newUnit = new MilitaryUnit(present, radius, lon, lat, symbolID);
            unitsList[i] = newUnit;
        }

        return unitsList;
    }
}