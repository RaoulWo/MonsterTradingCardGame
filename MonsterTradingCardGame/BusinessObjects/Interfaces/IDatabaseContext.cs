using Npgsql;

namespace BusinessObjects.Interfaces
{
    public interface IDatabaseContext
    {
        NpgsqlConnection Connection { get; }
        void Dispose();
    }
}
