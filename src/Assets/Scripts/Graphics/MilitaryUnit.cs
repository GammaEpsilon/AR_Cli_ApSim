public class MilitaryUnit {
    public bool Present
    { get; set; }
    public double Radius
    { get; set; }
    public double Lat
    { get; set; }
    public double Lon
    { get; set; }
    public string SymbolID
    { get; set; }
    
    
    public MilitaryUnit(bool present, double radius, double lat, double lon, string symbolID) {
        Present = present;
        Radius = radius;
        Lat = lat;
        Lon = lon;
        SymbolID = symbolID;
    }
}