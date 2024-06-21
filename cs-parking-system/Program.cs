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
                // Report no. 3
                case "license_plate_with_odd_even": case "lpwoe":
                    break;
                // Report no. 4
                case "license_plate_with_type": case "lpwt":
                    string vehicleType = commandParts[1];
                    parkingLogic?.GetVehiclesByType(vehicleType);
                    break;
                // Report no. 5
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
