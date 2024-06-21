public class ParkingLogic
{
    private List<ParkingSlot> parkingSlots;
    
    public ParkingLogic(int totalSlot)
    {
        parkingSlots = new List<ParkingSlot>(totalSlot);
        for (int i = 0; i < totalSlot; i++)
        {
            parkingSlots.Add(new ParkingSlot(i));
        }
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        var availableSlot = parkingSlots.FirstOrDefault(lot => lot.parkedVehicle == null);
        if (availableSlot == null)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }
        
        availableSlot.parkedVehicle = vehicle;
        Console.WriteLine($"Allocated slot number: {availableSlot.slotNumber + 1}");
    }

    public void Leave(int slotNumber)
    {
        var slot = parkingSlots.FirstOrDefault(l => l.slotNumber == slotNumber);
        if (slot == null || slot.parkedVehicle == null)
        {
            Console.WriteLine($"Slot number {slotNumber} is already free");
            return;
        }

        slot.parkedVehicle = null;
        Console.WriteLine($"Slot number {slotNumber} is free");
    }

    public void Status()
    {
        Console.WriteLine("Slot\tLicense Plate\tType\tColor");
        foreach (var lot in parkingSlots)
        {
            if (lot.parkedVehicle != null)
            {
                Console.WriteLine($"{lot.slotNumber + 1}\t{lot.parkedVehicle.licensePlate}\t{lot.parkedVehicle.vehicleType}\t{lot.parkedVehicle.color}");
            }
        }
    }

    // Report no. 4
    public void GetVehiclesByType(string vehicleType)
    {
        var vehicles = parkingSlots
            .Where(lot => lot.parkedVehicle?.vehicleType.Equals(vehicleType, StringComparison.OrdinalIgnoreCase) == true)
            .Select(lot => lot.parkedVehicle?.licensePlate)
            .ToList();
        
        if (vehicles.Any())
        {
            Console.WriteLine("Vehicle count with type " + vehicleType + ": " + vehicles.Count);
            Console.WriteLine(string.Join(" ", vehicles));
        }
        else
        {
            Console.WriteLine("Vehicle with type " + vehicleType + " is not found");
        }
    }

    // Report no. 5
    public void GetVehiclesByColor(string color)
    {
        var vehicles = parkingSlots
            .Where(lot => lot.parkedVehicle?.color.Equals(color, StringComparison.OrdinalIgnoreCase) == true)
            .Select(lot => lot.parkedVehicle?.licensePlate)
            .ToList();
        
        if (vehicles.Any())
        {
            Console.WriteLine("Vehicle count with color " + color + ": " + vehicles.Count);
            Console.WriteLine(string.Join(" ", vehicles));
        }
        else
        {
            Console.WriteLine("Vehicle with color " + color + " is not found");
        }
    }
}
