using Dapper;
using EntityModels;
using System.Data;

namespace DataAccessLayer.SQL;

internal class ParkingSpaceDao : BaseDao<IDataContext<IDbConnection>>, IDao<ParkingSpaceEntity>
{
    public ParkingSpaceDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
    {
    }

    public int Create(ParkingSpaceEntity model)
    {
        string sql = "INSERT INTO \"ParkingSpace\" (\"status\", \"booth_number\", \"parking_lot_id\") VALUES(@Status, @BoothNumber, @ParkingLot_id);";
        using (IDbConnection connection = DataContext.Open())
        {
            return connection.Execute(sql, model);

        };
    }

    public int Delete(ParkingSpaceEntity model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ParkingSpaceEntity> ReadAll(ParkingSpaceEntity model)
    {
        // TODO complete sql for parameter binding
        // COALESCE tries arguments until succes 
        string sql = "SELECT * FROM \"ParkingSpace\" WHERE \"status\" = COALESCE(@status, \"status\") AND \"id\" = COALESCE(@id, \"id\") AND \"parking_lot_id\" = COALESCE(@parking_lot_id, \"parking_lot_id\") and \"booth_number\" = COALESCE(@booth_number, \"booth_number\" );";


        using (IDbConnection connection = DataContext.Open())
        {
            return connection.Query<ParkingSpaceEntity>(sql, model);

        };
    }

    public ParkingSpaceEntity ReadById(int id)
    {
        string sql = "SELECT * FROM \"ParkingSpace\" WHERE \"id\" = @id";


        using (IDbConnection connection = DataContext.Open())
        {
            return connection.QueryFirst<ParkingSpaceEntity>(sql, id);

        };
    }

    public int Update(ParkingSpaceEntity model)
    {
        // TODO Optimistic concurrency control
        string sql = "UPDATE \"ParkingSpace\" SET \"status\" = @status WHERE \"id\" = @id";
        using (IDbConnection connection = DataContext.Open())
        {
            int res = connection.Execute(sql, model);
            return res;

        };
    }
}
