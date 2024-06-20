class Vehicle
{
    public required string LicensePlate { get; set; }
    public required string Color { get; set; }
    public required string VehicleType { get; set; }
    
    public Vehicle(string licensePlate, string color, string vehicleType)
    {
        LicensePlate = licensePlate;
        Color = color;
        VehicleType = vehicleType;
    }
}