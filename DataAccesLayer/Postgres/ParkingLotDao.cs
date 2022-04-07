using Dapper;
using EntityModels;
using System.Data;

namespace DataAccessLayer.SQL;

internal class ParkingLotDao : BaseDao<IDataContext<IDbConnection>>, IDao<ParkingLotEntity>
{

    public ParkingLotDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
    {
    }

    public int Create(ParkingLotEntity model)
    {
        throw new NotImplementedException();
    }

    public int Delete(ParkingLotEntity model)
    {
        string sql = "DELETE FROM \"ParkingLot\" WHERE \"id\" = @id";
        using (IDbConnection connection = DataContext.Open())
        {
            return connection.Execute(sql, model);

        };
    }

    public IEnumerable<ParkingLotEntity> ReadAll(ParkingLotEntity model)
    {
        string sql = "SELECT * FROM \"ParkingLot\"";
        using (IDbConnection connection = DataContext.Open())
        {
            return connection.Query<ParkingLotEntity>(sql);

        };

    }

    public ParkingLotEntity ReadById(int id)
    {
        string sql = "SELECT * FROM \"ParkingLot\" WHERE \"id\" = @id";


        using (IDbConnection connection = DataContext.Open())
        {
            return connection.QueryFirst<ParkingLotEntity>(sql, id);

        };
    }

    public int Update(ParkingLotEntity model)
    {
        throw new NotImplementedException();
    }
}
