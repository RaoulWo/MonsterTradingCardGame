using System.Data.SqlClient;

namespace BusinessObjects.Interfaces
{
    public interface IDatabaseContext
    {
        SqlConnection Connection { get; }
        void Dispose();
    }
}
