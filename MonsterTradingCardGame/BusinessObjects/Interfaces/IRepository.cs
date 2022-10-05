using BusinessObjects.Base;
using Npgsql;

namespace BusinessObjects.Interfaces
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        public Task<IEnumerable<T>> GetAll(string getAllSql);
        public Task<T> GetById(int id, string getByIdSql);
        public Task<int> Insert(T entity, string insertSql, NpgsqlTransaction sqlTransaction);
        public Task<int> Update(T entity, string updateSql, NpgsqlTransaction sqlTransaction);
        public Task<int> DeleteById(int id, string deleteSql, NpgsqlTransaction sqlTransaction);
    }
}
