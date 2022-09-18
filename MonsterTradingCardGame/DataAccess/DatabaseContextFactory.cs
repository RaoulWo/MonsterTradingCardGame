using BusinessObjects.Interfaces;

namespace DataAccess
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext _databaseContext;

        public IDatabaseContext Context()
        {
            return _databaseContext ??= new DatabaseContext();
        }

        public void Dispose()
        {
            if (_databaseContext != null) _databaseContext.Dispose();
        }
    }
}
