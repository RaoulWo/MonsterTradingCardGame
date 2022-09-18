
using System.Data.SqlClient;

namespace BusinessObjects.Interfaces
{
    public interface IUnitOfWork
    {
        IDatabaseContext DatabaseContext { get; }
        SqlTransaction BeginTransaction();

        void CommitTransaction();
    }
}
