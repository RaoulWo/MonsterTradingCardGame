using System.Data;
using BusinessObjects.Base;
using BusinessObjects.Interfaces;
using Npgsql;

namespace DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, IAggregateRoot, new()
    {
        protected NpgsqlConnection _connection;
        protected readonly IUnitOfWork UnitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
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
        public async Task<IEnumerable<T>> GetAll(string getAllSql)
        {
            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = getAllSql;
                    cmd.CommandType = CommandType.Text;

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
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
        public async Task<T> GetById(int id, string getByIdSql)
        {
            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = getByIdSql;
                    cmd.CommandType = CommandType.Text;
                    GetByIdCommandParameters(id, cmd);

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
        /// Base method for inserting data.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="insertSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public async Task<int> Insert(T entity, string insertSql, NpgsqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
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
        public async Task<int> Update(T entity, string updateSql, NpgsqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
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
        public async Task<int> DeleteById(int id, string deleteSql, NpgsqlTransaction sqlTransaction)
        {
            int rowsAffected = 0;

            try
            {
                using (NpgsqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = deleteSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;

                    DeleteByIdCommandParameters(id, cmd);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        protected abstract List<T> Maps(NpgsqlDataReader reader);
        protected abstract T Map(NpgsqlDataReader reader);
        protected abstract void GetByIdCommandParameters(int id, NpgsqlCommand cmd);
        protected abstract void InsertCommandParameters(T entity, NpgsqlCommand cmd);
        protected abstract void UpdateCommandParameters(T entity, NpgsqlCommand cmd);
        protected abstract void DeleteByIdCommandParameters(int id, NpgsqlCommand cmd);
    }
}
