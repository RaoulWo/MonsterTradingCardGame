using System.Data.SqlClient;
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByName(string name, string getByNameSql);
        public Task<int> Delete(string name, string deleteSql, SqlTransaction sqlTransaction);
    }
}
