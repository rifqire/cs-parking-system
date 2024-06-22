# Parking Management System

This C# application is designed to manage a parking lot, allowing users to add, remove, and view vehicles. The system comprises three main classes: `Vehicle`, `ParkingSlot`, and `ParkingLogic`. The entry point of the application is `Program.cs`, which contains a switch case to handle user commands.

## Table of Contents

1. [Classes](#classes)
   - [Vehicle](#vehicle)
   - [ParkingSlot](#parkinglot)
   - [ParkingLogic](#parkinglogic)
2. [Program.cs](#programcs)
3. [How to Use](#how-to-use)

## Classes

### Vehicle

The `Vehicle` class represents a vehicle that can park in the parking lot. It contains properties such as the vehicle's license plate, number and vehicle type.

```csharp
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
```

### ParkingSlot

The `ParkingSlot` class represents the parking lot itself. It contains a slot number and the vehicle itself

```csharp
public class ParkingSlot
{
    public int slotNumber { get; set; }
    public Vehicle? parkedVehicle { get; set; }

    public ParkingSlot(int slotNumber)
    {
        this.slotNumber = slotNumber;
    }
}
```

### ParkingLogic

The `ParkingLogic` class contains the business logic for managing the parking lot. It interacts with the `ParkingSlot` and `Vehicle` classes to perform operations.

To create a new parking lot:
```csharp
    private List<ParkingSlot> parkingSlots;

    public ParkingLogic(int totalSlot)
    {
        parkingSlots = new List<ParkingSlot>(totalSlot);
        for (int i = 0; i < totalSlot; i++)
        {
            parkingSlots.Add(new ParkingSlot(i));
        }
    }
```

To park the vehicle and assign the empty slot sequentially:
```csharp
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
```

To empty a parking slot and remove the parked vehicle:
```csharp
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
```

To view the list of parked vehicles:
```csharp
    public void Status()
    {
        Console.WriteLine("Slot\tLicense Plate\tType\tColor");
        foreach (var lot in parkingSlots)
        {
            Console.WriteLine($"{lot.slotNumber + 1}\t{lot.parkedVehicle?.licensePlate}\t{lot.parkedVehicle?.vehicleType}\t{lot.parkedVehicle?.color}");
        }
    }
```

To count the filled parking slots:
```csharp
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
```

To count the empty parking slots:
```csharp
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
```

To view the list and count the vehicles based on odd/even license plates:
```csharp
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
```

To view the list and count the vehicle based on type:
```csharp
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
```

To view the list and count the vehicle based on color:
```csharp
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
```

## Program.cs

The `Program.cs` file is the entry point of the application. It contains a `Main` method with a switch case to handle user commands.

```csharp
class Program
{
    static void Main(string[] args)
    {
        ParkingLogic? parkingLogic = null;

        while (true)
        {
            var input = Console.ReadLine();
            var commandParts = input?.Split(' ');

            switch (commandParts?[0])
            {
                case "create_parking_lot": case "cpl":
                    int totalLots = int.Parse(commandParts[1]);
                    parkingLogic = new ParkingLogic(totalLots);
                    Console.WriteLine($"Created a parking lot with {totalLots} slots");
                    break;
                case "park_vehicle": case "pv":
                    var vehicle = new Vehicle(commandParts[1].ToUpper(), commandParts[2], commandParts[3]);
                    parkingLogic?.ParkVehicle(vehicle);
                    break;
                case "leave_parking_lot": case "lpl":
                    int slotNumber = int.Parse(commandParts[1]);
                    parkingLogic?.Leave(slotNumber);
                    break;
                case "status": case "s":
                    parkingLogic?.Status();
                    break;
                // Report no. 1
                case "filled_slots": case "fs":
                    parkingLogic?.GetFilledSlots();
                    break;
                // Report no. 2
                case "empty_slots": case "es":
                    parkingLogic?.GetEmptySlots();
                    break;
                // Report no. 3, lpwoe odd, lpwoe even
                case "license_plate_with_odd_even": case "lpwoe":
                    string selector = commandParts[1];
                    parkingLogic?.GetVehiclesByOddEven(selector);
                    break;
                // Report no. 4, lpwt car, lpwt bike etc.
                case "license_plate_with_type": case "lpwt":
                    string vehicleType = commandParts[1];
                    parkingLogic?.GetVehiclesByType(vehicleType);
                    break;
                // Report no. 5, lpwc black, lpwc pink etc.
                case "license_plate_with_color": case "lpwc":
                    string color = commandParts[1];
                    parkingLogic?.GetVehiclesByColor(color);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }
    }
}
```

## How to Use

1. Run the application.
2. Select an option by typing the corresponding command (long or short form) and pressing Enter.
3. To exit the application, type `return` and press Enter.
