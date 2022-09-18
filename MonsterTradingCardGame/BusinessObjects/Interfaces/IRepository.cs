using System.Data.SqlClient;
using BusinessObjects.Base;

namespace BusinessObjects.Interfaces
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        IEnumerable<T> GetAll(string getAllSql);

        T GetById(int id, string getByIdSql);

        int Insert(T entity, string insertSql, SqlTransaction sqlTransaction);

        int Update(T entity, string updateSql, SqlTransaction sqlTransaction);

        int Delete(int id, string deleteSql, SqlTransaction sqlTransaction);
    }
}
