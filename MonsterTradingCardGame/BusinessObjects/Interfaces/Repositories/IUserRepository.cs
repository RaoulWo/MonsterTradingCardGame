using BusinessObjects.Models;
using Npgsql;

namespace BusinessObjects.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByName(string name, string getByNameSql);
        public Task<int> DeleteByName(string name, string deleteSql, NpgsqlTransaction sqlTransaction);
    }
}
