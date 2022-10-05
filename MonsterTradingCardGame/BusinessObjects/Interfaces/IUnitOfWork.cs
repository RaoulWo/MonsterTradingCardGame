using Npgsql;

namespace BusinessObjects.Interfaces
{
    public interface IUnitOfWork
    {
        IDatabaseContext DatabaseContext { get; }
        NpgsqlTransaction BeginTransaction();

        void CommitTransaction();
    }
}
