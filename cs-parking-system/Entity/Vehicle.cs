public class Vehicle
{
    public string licensePlate { get; set; }
    public string vehicleType { get; set; }
    public string color { get; set; }
    

    public Vehicle(string licensePlate, string vehicleType, string color)
    {
        this.licensePlate = licensePlate;
        this.vehicleType = vehicleType;
        this.color = color;
    }
}