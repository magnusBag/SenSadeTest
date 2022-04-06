namespace sensade_project.Dto;

public class ParkingLotDto : BaseDto
{
    public string RoadName { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public double Latitide { get; set; }

    public double Longitude { get; set; }
}
