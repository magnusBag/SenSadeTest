using DataAccessLayer.SQL;
using EntityModels;
using System.Data;

namespace DataAccessLayer;

public static class DaoFactory
{
    public static IDao<T> Create<T>(IDataContext dataContext)
    {
        return typeof(T) switch
        {

            var dao when dao == typeof(ParkingSpaceEntity) => new ParkingSpaceDao(dataContext as IDataContext<IDbConnection>) as IDao<T>,
            var dao when dao == typeof(ParkingLotEntity) => new ParkingLotDao(dataContext as IDataContext<IDbConnection>) as IDao<T>,

            _ => throw new DaoFactoryException("could not create dao from factory"),
        };
    }
}
