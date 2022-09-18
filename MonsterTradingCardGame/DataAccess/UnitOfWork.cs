using System.Data.SqlClient;
using BusinessObjects.Interfaces;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public SqlTransaction Transaction { get; private set; }

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
        public UnitOfWork(IDatabaseContextFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Begins a database transaction.
        /// </summary>
        /// <returns></returns>
        public SqlTransaction BeginTransaction()
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
