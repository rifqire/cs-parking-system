class ParkingLot
{
    public required int SlotNumber { get; set; }
    public Vehicle? ParkedVehicle { get; set; }
    public bool IsOccupied { get; set; }

    public ParkingLot(int slotNumber, bool isOccupied)
    {
        SlotNumber = slotNumber;
        IsOccupied = isOccupied;
    }
}