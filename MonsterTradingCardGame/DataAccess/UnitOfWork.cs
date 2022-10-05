using BusinessObjects.Interfaces;
using Npgsql;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public static IUnitOfWork Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new UnitOfWork(new DatabaseContextFactory());
                }

                return _singleton;
            }
        }

        private static IUnitOfWork _singleton = null;

        public NpgsqlTransaction Transaction { get; private set; }

        /// <summary>
        /// Property for the DatabaseContext.
        /// </summary>
        public IDatabaseContext DatabaseContext
        {
            get
            {
                return _context ??= _factory.Context();
            }
        }

        private IDatabaseContextFactory _factory;
        private IDatabaseContext _context;

        /// <summary>
        /// Initializes the DatabaseContextFactory.
        /// </summary>
        /// <param name="factory"></param>
        private UnitOfWork(IDatabaseContextFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Begins a database transaction.
        /// </summary>
        /// <returns></returns>
        public NpgsqlTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Previous transaction is not completed");
            }

            Transaction = _context.Connection.BeginTransaction();
            return Transaction;
        }

        /// <summary>
        /// Uses Commit or Rollback of memory data into database.
        /// </summary>
        public void CommitTransaction()
        {
            if (Transaction != null)
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                }
                finally
                {
                    Transaction.Dispose();
                    Transaction = null;
                }
            }
            else
            {
                throw new NullReferenceException("Cannot commit non-existent transaction");
            }
        }

        /// <summary>
        /// Disposes a the transaction.
        /// </summary>
        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
