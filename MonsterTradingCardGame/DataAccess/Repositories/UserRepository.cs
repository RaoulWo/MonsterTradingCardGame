using System.Data.SqlClient;
using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Repositories;
using BusinessObjects.Models;

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
        /// Maps data for populating all statement.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override List<User> Maps(SqlDataReader reader)
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
        protected override User Map(SqlDataReader reader)
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
        protected override void GetByIdCommandParameters(int id, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters for insert statement.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(User entity, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Username", entity.Username);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
        }

        /// <summary>
        /// Passes the parameters for update statement.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(User entity, SqlCommand cmd)
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
        protected override void DeleteCommandParameters(int id, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }
    }
}
