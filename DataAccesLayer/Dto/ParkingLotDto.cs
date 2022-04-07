namespace DataAccessLayer;

public class ParkingLotDto : BaseDto
{
    public string? RoadName { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public double Latitide { get; set; }

    public double Longitude { get; set; }

    public string? Avaliable { get; set; }
}
