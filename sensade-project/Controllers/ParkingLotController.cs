using DataAccessLayer;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using sensade_project.util;

namespace sensade_project.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParkingLotController : Controller
{
    private IDao<ParkingSpaceEntity> _parkingSpaceDao;
    private IDao<ParkingLotEntity> _parkingLotDao;
    public ParkingLotController(IDao<ParkingSpaceEntity> dao, IDao<ParkingLotEntity> dao1)
    {
        _parkingSpaceDao = dao;
        _parkingLotDao = dao1;
    }

    public ActionResult Index()
    {
        try
        {
            var res = _parkingLotDao.ReadAll(new ParkingLotEntity()).Select(x => x.Map());
            return Ok(res);
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

    [Route("avaliable")]
    [Route("avaliable/{id:int}")]
    public ActionResult Avaliable(int? id)
    {
        try
        {
            var res = _parkingSpaceDao.ReadAll(new ParkingSpaceEntity() { Parking_lot_id = id, Status = true }).Count();
            return Ok(res);
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        //Does cascade delete, be carefull
        try
        {
            int res = _parkingLotDao.Delete(new ParkingLotEntity() { Id = id });
            if (res > 0) return Ok($"parking lot with id: {id} and all spaces on it were deleted");
            else return BadRequest("could not find parkinglot with that id");
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }
}
