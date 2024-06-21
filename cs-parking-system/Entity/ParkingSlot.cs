public class ParkingSlot
{
    public int slotNumber { get; set; }
    public Vehicle? parkedVehicle { get; set; }

    public ParkingSlot(int slotNumber)
    {
        this.slotNumber = slotNumber;
    }
}