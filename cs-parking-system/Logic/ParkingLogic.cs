using System.Text.RegularExpressions;

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
            Console.WriteLine($"{lot.slotNumber + 1}\t{lot.parkedVehicle?.licensePlate}\t{lot.parkedVehicle?.vehicleType}\t{lot.parkedVehicle?.color}");
        }
    }

    // Report no. 1
    public void GetFilledSlots()
    {
        var filledSlotCount = parkingSlots
            .Where(lot => lot.parkedVehicle?.licensePlate != null)
            .Select(lot => lot.parkedVehicle?.licensePlate)
            .Count();

        if (filledSlotCount > 0)
        {
            Console.WriteLine("Filled slots: " + filledSlotCount);
        }
        else
        {
            Console.WriteLine("There is no filled slots!");
        }
    }

    // Report no. 2
    public void GetEmptySlots()
    {
        var emptySlotCount = parkingSlots
            .Where(lot => lot.parkedVehicle?.licensePlate == null)
            .Select(lot => lot.parkedVehicle?.licensePlate)
            .Count();

        if (emptySlotCount > 0)
        {
            Console.WriteLine("Empty slots: " + emptySlotCount);
        }
        else
        {
            Console.WriteLine("There is no empty slots!");
        }
    }

    // Report no. 3
    public void GetVehiclesByOddEven(string selector)
    {
        var vehicles = parkingSlots
                .Where(lot => lot.parkedVehicle?.licensePlate != null)
                .Select(lot => lot.parkedVehicle?.licensePlate)
                .ToList();

        List<int> numbers = new List<int>();
        List<string> resultPlates = new List<string>();

        switch (selector)
        {
            case "odd":
                foreach (string str in vehicles)
                {
                    string[] numbersOnly = str.Split('-');
                    if (int.TryParse(numbersOnly[1], out int number))
                    {
                        if (number % 2 == 1)
                        {
                            numbers.Add(number);
                            resultPlates.Add(str);
                        }
                    }
                }

                if (numbers.Any())
                {
                    Console.WriteLine("Vehicle count with odd plates: " + numbers.Count);
                    Console.WriteLine(string.Join(" ", resultPlates));
                }
                else
                {
                    Console.WriteLine("Vehicle with odd plates does not exist!");
                }
                break;
            case "even":
                foreach (string str in vehicles)
                {
                    string[] numbersOnly = str.Split('-');
                    if (int.TryParse(numbersOnly[1], out int number))
                    {
                        if (number % 2 != 1)
                        {
                            numbers.Add(number);
                            resultPlates.Add(str);
                        }
                    }
                }

                if (numbers.Any())
                {
                    Console.WriteLine("Vehicle count with even plates: " + numbers.Count);
                    Console.WriteLine(string.Join(" ", resultPlates));
                }
                else
                {
                    Console.WriteLine("Vehicle with odd plates does not exist!");
                }
                break;
            default:
                Console.WriteLine("Invalid option! Only use 'odd' or 'even'.");
                break;
        }
    }

    // Report no. 4
    public void GetVehiclesByType(string vehicleType)
    {
        var vehicles = parkingSlots
            .Where(lot => lot.parkedVehicle?.vehicleType.Equals(vehicleType) == true)
            .Select(lot => lot.parkedVehicle?.licensePlate)
            .ToList();

        if (vehicles.Any())
        {
            Console.WriteLine("Vehicle count with type " + vehicleType + ": " + vehicles.Count);
            Console.WriteLine(string.Join(" ", vehicles));
        }
        else
        {
            Console.WriteLine("Vehicle with type " + vehicleType + " does not exist");
        }
    }

    // Report no. 5
    public void GetVehiclesByColor(string color)
    {
        var vehicles = parkingSlots
            .Where(lot => lot.parkedVehicle?.color.Equals(color) == true)
            .Select(lot => lot.parkedVehicle?.licensePlate)
            .ToList();

        if (vehicles.Any())
        {
            Console.WriteLine("Vehicle count with color " + color + ": " + vehicles.Count);
            Console.WriteLine(string.Join(" ", vehicles));
        }
        else
        {
            Console.WriteLine("Vehicle with color " + color + " does not exist");
        }
    }
}
