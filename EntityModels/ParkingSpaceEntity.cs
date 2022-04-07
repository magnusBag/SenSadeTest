namespace EntityModels;

public class ParkingSpaceEntity : BaseEntity
{
    public bool? Status { get; set; }
    public int? Booth_number { get; set; }
    public int? Parking_lot_id { get; set; }

}
