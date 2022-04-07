namespace EntityModels;

public class ParkingLotEntity : BaseEntity
{
    public string? Road_Name { get; set; }

    public string? City { get; set; }

    public string? Zip_Code { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
