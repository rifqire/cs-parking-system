public class Vehicle
{
    public string licensePlate { get; set; }
    public string color { get; set; }
    public string vehicleType { get; set; }

    public Vehicle(string licensePlate, string color, string vehicleType)
    {
        this.licensePlate = licensePlate;
        this.color = color;
        this.vehicleType = vehicleType;
    }
}