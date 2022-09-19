using System.Data;
using System.Data.SqlClient;
using BusinessObjects.Base;
using BusinessObjects.Interfaces;

namespace DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, IAggregateRoot, new()
    {
        private SqlConnection _connection;
        protected readonly IUnitOfWork UnitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            UnitOfWork = unitOfWork;
            _connection = UnitOfWork.DatabaseContext.Connection;
        }

        /// <summary>
        /// Base method for populating all data.
        /// </summary>
        /// <param name="getAllSql"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string getAllSql)
        {
            try
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = getAllSql;
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return Maps(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Base method for populating by key.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getByIdSql"></param>
        /// <returns></returns>
        public T GetById(int id, string getByIdSql)
        {
            try
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = getByIdSql;
                    cmd.CommandType = CommandType.Text;
                    GetByIdCommandParameters(id, cmd);

                    using (SqlDataReader reader = cmd.ExecuteReader())
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
        /// Base method for inserting data.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="insertSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Insert(T entity, string insertSql, SqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = insertSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;

                    InsertCommandParameters(entity, cmd);
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
        /// Base method for updating data.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Update(T entity, string updateSql, SqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = updateSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;

                    UpdateCommandParameters(entity, cmd);
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
        /// Base Method for deleting data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleteSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Delete(int id, string deleteSql, SqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = deleteSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;

                    DeleteCommandParameters(id, cmd);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        protected abstract List<T> Maps(SqlDataReader reader);
        protected abstract T Map(SqlDataReader reader);
        protected abstract void GetByIdCommandParameters(int id, SqlCommand cmd);
        protected abstract void InsertCommandParameters(T entity, SqlCommand cmd);
        protected abstract void UpdateCommandParameters(T entity, SqlCommand cmd);
        protected abstract void DeleteCommandParameters(int id, SqlCommand cmd);
    }
}
