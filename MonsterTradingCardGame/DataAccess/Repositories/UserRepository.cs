using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Repositories;
using BusinessObjects.Models;
using Npgsql;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public static IUserRepository Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new UserRepository(DataAccess.UnitOfWork.Singleton);
                }

                return _singleton;
            }
        }

        private static IUserRepository _singleton = null;

        private UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) 
        { }

        /// <summary>
        /// Base method for populating by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="getByNameSql"></param>
        /// <returns></returns>
        public async Task<User> GetByName(string name, string getByNameSql)
        {
            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = getByNameSql;
                    cmd.CommandType = CommandType.Text;
                    GetByNameCommandParameters(name, cmd);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        return Map(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Base method for deleting data.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="deleteSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public async Task<int> DeleteByName(string name, string deleteSql, NpgsqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = deleteSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;

                    DeleteCommandParameters(name, cmd);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        /// <summary>
        /// Maps data for populating all statement.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override List<User> Maps(NpgsqlDataReader reader)
        {
            List<User> users = new List<User>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();

                    user.Id = Convert.ToInt32(reader["Id"].ToString());
                    user.Username = reader["Username"].ToString();
                    user.Password = reader["Password"].ToString();

                    users.Add(user);
                }
            }

            return users;
        }

        /// <summary>
        /// Maps data for populating by key statement.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override User Map(NpgsqlDataReader reader)
        {
            User user = new User();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["Id"].ToString());
                    user.Username = reader["Username"].ToString();
                    user.Password = reader["Password"].ToString();
                }
            }

            return user;
        }

        /// <summary>
        /// Passes the parameters for populating by key statement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void GetByIdCommandParameters(int id, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters for populating by name statement.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cmd"></param>
        protected void GetByNameCommandParameters(string name, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Username", name);
        }

        /// <summary>
        /// Passes the parameters for insert statement.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(User entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Username", entity.Username);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
        }

        /// <summary>
        /// Passes the parameters for update statement.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(User entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Username", entity.Username);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
        }

        /// <summary>
        /// Passes the parameters for delete statement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void DeleteCommandParameters(int id, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters for delete statement.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cmd"></param>
        protected void DeleteCommandParameters(string name, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Username", name);
        }
    }
}
