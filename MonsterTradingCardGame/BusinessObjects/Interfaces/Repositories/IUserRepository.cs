using BusinessObjects.Entities;
using Npgsql;

namespace BusinessObjects.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        public Task<UserEntity> GetByName(string name, string getByNameSql);
        public Task<int> DeleteByName(string name, string deleteSql, NpgsqlTransaction sqlTransaction);
    }
}
