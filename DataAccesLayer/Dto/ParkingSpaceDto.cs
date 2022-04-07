namespace DataAccessLayer;

public class ParkingSpaceDto : BaseDto
{
    public bool? Status { get; set; }

    public int? BoothNumber { get; set; }

    public string? Parking_lot_href { get; set; }

}
