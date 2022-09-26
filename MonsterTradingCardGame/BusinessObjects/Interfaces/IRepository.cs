using System.Data.SqlClient;
using BusinessObjects.Base;

namespace BusinessObjects.Interfaces
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        public Task<IEnumerable<T>> GetAll(string getAllSql);
        public Task<T> GetById(int id, string getByIdSql);
        public Task<int> Insert(T entity, string insertSql, SqlTransaction sqlTransaction);
        public Task<int> Update(T entity, string updateSql, SqlTransaction sqlTransaction);
        public Task<int> Delete(int id, string deleteSql, SqlTransaction sqlTransaction);
    }
}
