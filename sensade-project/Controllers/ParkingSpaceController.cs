using DataAccessLayer;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using sensade_project.util;

namespace sensade_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingSpaceController : Controller
{
    private IDao<ParkingSpaceEntity> _parkingSpaceDao;
    public ParkingSpaceController(IDao<ParkingSpaceEntity> dao)
    {
        _parkingSpaceDao = dao;
    }
    // GET: ParkingSpaceController
    [HttpGet]
    public ActionResult Index([FromQuery] ParkingSpaceDto parkingSpace)
    {
        //TODO: Use parameter  object for parameterbinding
        try
        {
            var res = _parkingSpaceDao.ReadAll(new ParkingSpaceEntity()
            {
                Id = parkingSpace.ExtractId(),
                Status = parkingSpace.Status,
                Parking_lot_id = Mapper.GetIdFromHref(parkingSpace.Parking_lot_href!),
                Booth_number = parkingSpace.BoothNumber
            }).Select(x => x.Map());
            return Ok(res);

        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }
    [Route("{id}")]
    public ActionResult Details(int id)
    {
        try
        {
            var res = _parkingSpaceDao.ReadById(id);
            return Ok(res);
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

    [Route("Avaliable")]
    public ActionResult Avaliable()
    {
        try
        {
            var res = _parkingSpaceDao.ReadAll(new ParkingSpaceEntity() { Status = true }).Count();
            return Ok(res);
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

    [HttpPost]
    public ActionResult Create(ParkingSpaceDto parkingSpace)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

    [HttpPut]
    public ActionResult Update([FromBody] ParkingSpaceDto parkingSpace)
    {
        try
        {
            return Ok(_parkingSpaceDao.Update(parkingSpace.Map()));
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

    [HttpDelete]
    public ActionResult Delete([FromQuery] int id)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch
        {
            return BadRequest("could not complete request");
        }
    }

}
