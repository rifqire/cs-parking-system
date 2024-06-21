public class ParkingLot
{
        public int slotNumber { get; set; }
    public Vehicle? parkedVehicle { get; set; }

    public ParkingLot(int slotNumber)
    {
        this.slotNumber = slotNumber;
    }
}