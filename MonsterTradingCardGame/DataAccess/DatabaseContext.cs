using System.Data;
using BusinessObjects.Interfaces;
using Npgsql;

namespace DataAccess
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly string _connectionString;
        private NpgsqlConnection _connection;

        /// <summary>
        /// Gets connection string from web.config when class is initialized.
        /// </summary>
        public DatabaseContext()
        {
            _connectionString =
                "Host=localhost;Port=5432;Username=postgres;Database=MonsterTradingCardGame";
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public NpgsqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new NpgsqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        /// <summary>
        /// Disposes the connection.
        /// </summary>
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
