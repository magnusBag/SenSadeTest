using DataAccessLayer;
using EntityModels;

namespace sensade_project.util;
// Class for mapping between DTO and Entity 
public static class Mapper
{
    public static ParkingLotDto Map(this ParkingLotEntity parkingLot)
    {
        if (parkingLot == null) return null;
        return new ParkingLotDto()
        {
            Href = parkingLot.ExtractHref(),
            RoadName = parkingLot.Road_Name!,
            City = parkingLot.City!,
            ZipCode = parkingLot.Zip_Code!,
            Latitide = parkingLot.Latitude!,
            Longitude = parkingLot.Longitude!,
            Avaliable = "api/parkingLot/avaliable/" + parkingLot.Id
        };
    }

    public static ParkingLotEntity Map(this ParkingLotDto parkingLot)
    {
        if (parkingLot == null) return null;
        return new ParkingLotEntity()
        {
            Id = parkingLot.ExtractId(),
            Road_Name = parkingLot.RoadName!,
            City = parkingLot.City!,
            Zip_Code = parkingLot.ZipCode!,
            Latitude = parkingLot.Latitide!,
            Longitude = parkingLot.Longitude!,
        };
    }

    public static ParkingSpaceDto Map(this ParkingSpaceEntity parkingSpace)
    {
        if (parkingSpace == null) return null;
        return new ParkingSpaceDto()
        {
            Href = parkingSpace.ExtractHref(),
            Status = parkingSpace.Status!,
            BoothNumber = parkingSpace.Booth_number!,
            Parking_lot_href = GetHrefFromId(typeof(ParkingLotEntity), parkingSpace.Parking_lot_id),
        };
    }

    public static ParkingSpaceEntity Map(this ParkingSpaceDto parkingSpace)
    {
        if (parkingSpace == null) return null;
        return new ParkingSpaceEntity()
        {
            Id = parkingSpace.ExtractId(),
            Status = parkingSpace.Status!,
            Booth_number = parkingSpace.BoothNumber!,
            Parking_lot_id = GetIdFromHref(parkingSpace.Parking_lot_href!),
        };
    }

    #region helperMethods
    public static int? ExtractId(this BaseDto dto)
    {
        return GetIdFromHref(dto.Href);
    }

    public static string ExtractHref(this BaseEntity model)
    {

        return GetHrefFromId(model.GetType(), model.Id);
    }

    public static string GetHrefFromId(Type type, int? id)
    {
        if (id == null) return null;
        string typeName = type.Name.Substring(0, type.Name.IndexOf("Entity"));
        return $@"api/{typeName}/{id}";
    }

    public static int? GetIdFromHref(string href)
    {
        if (string.IsNullOrEmpty(href)) return null;
        _ = int.TryParse(href[(href.LastIndexOf("/") + 1)..], out int result);
        return result;
    }
    #endregion

}
